using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFaseController : MonoBehaviour
{
    public static CardFaseController Instance { get; private set; }

    [SerializeField] Deck _deck;
    [SerializeField] Hand _hand;
    [SerializeField] Graveyard _graveyard;
    [SerializeField] GameObject _cardFasePanel;

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
        _cardFasePanel.SetActive(false);
    }

    public void CartFaseStarting()
    {
        NewTurn();
        _cardFasePanel.SetActive(true);
    }

    void NewTurn()
    {
        int currentHandCarts = _hand.CurrentHand;
        List<Cart> carts = _deck.NewTurn(currentHandCarts);
        _hand.NewTurn(carts);
    }

    public void SelectionDone(List<Cart> selectedCarts)
    {
        _cardFasePanel.SetActive(false);
        GeneralController.Instance.CardFaseDone(selectedCarts);
    }
}
