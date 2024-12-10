using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderworldController : MonoBehaviour
{
    public static UnderworldController Instance { get; private set; }

    [SerializeField] SO_UnderworldCards _SO_UnderworldCards;
    [SerializeField] CanvasGroup _UnderworldFasePanel;

    UnderworldDeck _deck;
    UnderworldHand _hand;
    UnderworldGraveyard _graveyard;

    List<UnderworldCard> _selectedUnderworldCards = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _deck = new UnderworldDeck(_SO_UnderworldCards);
            _hand = new UnderworldHand();
            _graveyard = new UnderworldGraveyard();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _UnderworldFasePanel.gameObject.SetActive(false);
    }

    public void UnderwordCardFaseStarting()
    {
        NewTurn();
        //_UnderworldFasePanel.gameObject.SetActive(true);
        //LeanTween.cancel(gameObject);
        //LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
        //    _UnderworldFasePanel.alpha = val);
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
        //_UnderworldFasePanel.gameObject.SetActive(false);
        //LeanTween.cancel(gameObject);
        //LeanTween.value(1, 0, 0.25f).setOnUpdate(val =>
        //    _UnderworldFasePanel.alpha = val);
    }

    public void UnderwordActionFaseStarting()
    {
        StartCoroutine(UnderwordActionFase());
    }

    IEnumerator UnderwordActionFase()
    {
        for (int i = 0; i < _selectedUnderworldCards.Count; i++)
        {
            Debug.Log(_selectedUnderworldCards[i].CardText);
            yield return new WaitForSeconds(1);
        }

        GeneralController.Instance.UnderworldActionDone();
    }
}
