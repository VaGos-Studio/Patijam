using System.Collections.Generic;
using UnityEngine;

public class CardFaseController : MonoBehaviour
{
    public static CardFaseController Instance { get; private set; }

    [SerializeField] SO_Deck _SO_Deck;
    [SerializeField] Hand _hand;
    [SerializeField] Graveyard _graveyard;
    [SerializeField] CanvasGroup _cardFasePanel;

    Deck _deck;
    bool _changeHand = false;
    bool _penombra = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _deck = new(_SO_Deck);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _cardFasePanel.gameObject.SetActive(false);
    }

    public void CardFaseStarting()
    {
        if (_penombra)
        {
            GeneralController.Instance.Penombra(true);
        }
        NewTurn();
        _cardFasePanel.gameObject.SetActive(true);
        LeanTween.cancel(gameObject);
        LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
            _cardFasePanel.alpha = val);
    }

    void NewTurn()
    {
        if (_changeHand)
        {
            List<Card> toReturn = _hand.ReturnHand();
            _deck.ReturnHand(toReturn);
            _changeHand = false;
        }

        int currentHandCarts = _hand.CurrentHand;
        List<Card> carts = _deck.NewTurn(currentHandCarts);
        _hand.NewTurn(carts);
    }

    public void SelectionDone(List<Card> selectedCarts)
    {
        _cardFasePanel.gameObject.SetActive(false);
        LeanTween.cancel(gameObject);
        LeanTween.value(1, 0, 0.25f).setOnUpdate(val =>
            _cardFasePanel.alpha = val);
        GeneralController.Instance.CardFaseDone(selectedCarts);
        if (_penombra)
        {
            GeneralController.Instance.Penombra(false);
            _penombra = false;
        }

    }

    public void QuickCardFase()
    {
        List<Card> emptyCards = new();
        SelectionDone(emptyCards);
    }

    public void ChangeNextHand()
    {
        _changeHand = true;
    }

    public void TurnOnPenombra()
    {
        _penombra = true;
    }
}
