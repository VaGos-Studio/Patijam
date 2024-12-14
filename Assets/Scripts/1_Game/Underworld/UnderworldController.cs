using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnderworldController : MonoBehaviour
{
    public static UnderworldController Instance { get; private set; }

    [SerializeField] SO_Deck _SO_Deck;
    [SerializeField] CanvasGroup _underworldFasePanel;
    [SerializeField] RectTransform _underworldCard;

    TMP_Text _cardNameText;
    TMP_Text _CardText;
    Image _CardImage;
    ParticleSystem _underworldParticle;

    UnderworldDeck _deck;
    UnderworldHand _hand = new();
    UnderworldGraveyard _graveyard = new();
    UnderworldActionSelector _actionSelector = new();

    List<Card> _selectedUnderworldCards = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _deck = new UnderworldDeck(_SO_Deck);

            TMP_Text[] texts = _underworldCard.gameObject.GetComponentsInChildren<TMP_Text>();
            _cardNameText = texts[0];
            _CardText = texts[1];
            _CardImage = _underworldCard.GetComponent<Image>();
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
        List<Card> carts = _deck.NewTurn(currentHandCarts);
        _hand.NewTurn(carts);
    }

    public void SelectionDone(List<Card> selectedCarts)
    {
        _selectedUnderworldCards = selectedCarts;
    }

    public void UnderwordActionFaseStarting()
    {
        _underworldFasePanel.gameObject.SetActive(true);
        LeanTween.cancel(gameObject);
        LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
            _underworldFasePanel.alpha = val);
        if (_selectedUnderworldCards.Count > 0)
        {
            StartCoroutine(UnderwordActionFase());
        }
        else
        {
            _underworldFasePanel.gameObject.SetActive(false);
            LeanTween.value(1, 0, 0.25f).setOnUpdate(val =>
                _underworldFasePanel.alpha = val);
            GeneralController.Instance.UnderworldActionDone();
        }
    }

    IEnumerator UnderwordActionFase()
    {
        for (int i = 0; i < _selectedUnderworldCards.Count; i++)
        {
            _underworldParticle.Clear();
            _cardNameText.text = _selectedUnderworldCards[i].CardAction.ToString();
            _CardText.text = _selectedUnderworldCards[i].CardText;
            _cardNameText.enabled = true;
            _CardText.enabled = true;
            _CardImage.enabled = true;
            LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
                _underworldCard.localScale = new Vector3(val, val, val));
            _underworldCard.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            _actionSelector.ExecuteUnderworldAction(_selectedUnderworldCards[i].CardAction);
            _underworldParticle.Play();
            _cardNameText.enabled = false;
            _CardText.enabled = false;
            _CardImage.enabled = false;
            yield return new WaitForSeconds(2f);
        }
        _underworldFasePanel.gameObject.SetActive(false);
        LeanTween.value(1, 0, 0.25f).setOnUpdate(val =>
            _underworldFasePanel.alpha = val);
        GeneralController.Instance.UnderworldActionDone();
    }

    public void SetAction(CARDACTIONS underworldAction)
    {
        _actionSelector.ExecuteUnderworldAction(underworldAction);
    }
}
