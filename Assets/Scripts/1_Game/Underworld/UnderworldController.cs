using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnderworldController : MonoBehaviour
{
    public static UnderworldController Instance { get; private set; }

    [SerializeField] SO_UnderworldCards _SO_UnderworldCards;
    [SerializeField] CanvasGroup _underworldFasePanel;
    [SerializeField] RectTransform _underworldCard;

    TMP_Text _underworldCardText;
    Image _underworldCardImage;
    ParticleSystem _underworldParticle;

    UnderworldDeck _deck;
    UnderworldHand _hand = new();
    UnderworldGraveyard _graveyard = new();
    UnderworldActionSelector _actionSelector = new();

    List<UnderworldCard> _selectedUnderworldCards = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _deck = new UnderworldDeck(_SO_UnderworldCards);

            _underworldCardText = _underworldCard.GetComponentInChildren<TMP_Text>();
            _underworldCardImage = _underworldCard.GetComponent<Image>();
            _underworldParticle = _underworldCard.GetComponentInChildren<ParticleSystem>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _underworldFasePanel.gameObject.SetActive(false);
    }

    public void UnderwordCardFaseStarting()
    {
        NewTurn();
    }

    void NewTurn()
    {
        int currentHandCarts = _hand.CurrentHand;
        List<UnderworldCard> carts = _deck.NewTurn(currentHandCarts);
        _hand.NewTurn(carts);
    }

    public void SelectionDone(List<UnderworldCard> selectedCarts)
    {
        _selectedUnderworldCards = selectedCarts;
    }

    public void UnderwordActionFaseStarting()
    {
        _underworldFasePanel.gameObject.SetActive(true);
        LeanTween.cancel(gameObject);
        LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
            _underworldFasePanel.alpha = val);
        StartCoroutine(UnderwordActionFase());
    }

    IEnumerator UnderwordActionFase()
    {
        for (int i = 0; i < _selectedUnderworldCards.Count; i++)
        {
            _underworldParticle.Clear();
            _underworldCardText.text = _selectedUnderworldCards[i].CardText;
            _underworldCardText.enabled = true;
            _underworldCardImage.enabled = true;
            LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
                _underworldCard.localScale = new Vector3(val, val, val));
            _underworldCard.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            _actionSelector.ExecuteUnderworldAction(_selectedUnderworldCards[i].UnderworldAction);
            _underworldParticle.Play();
            _underworldCardText.enabled = false;
            _underworldCardImage.enabled = false;
            yield return new WaitForSeconds(2f);
        }
        _underworldFasePanel.gameObject.SetActive(false);
        LeanTween.value(1, 0, 0.25f).setOnUpdate(val =>
            _underworldFasePanel.alpha = val);
        GeneralController.Instance.UnderworldActionDone();
    }
}
