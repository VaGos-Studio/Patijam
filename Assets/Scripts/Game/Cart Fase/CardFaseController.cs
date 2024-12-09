using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFaseController : MonoBehaviour
{
    public static CardFaseController Instance { get; private set; }

    [SerializeField] Deck _deck;
    [SerializeField] Hand _hand;
    [SerializeField] Graveyard _graveyard;
    [SerializeField] CanvasGroup _cardFasePanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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

    public void CartFaseStarting()
    {
        NewTurn();
        _cardFasePanel.gameObject.SetActive(true);
        LeanTween.cancel(gameObject);
        LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
            _cardFasePanel.alpha = val);
    }

    void NewTurn()
    {
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
    }

    public void QuickCardFase()
    {
        List<Card> emptyCards = new();
        SelectionDone(emptyCards);
    }
}
