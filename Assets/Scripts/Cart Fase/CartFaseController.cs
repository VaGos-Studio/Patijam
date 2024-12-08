using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartFaseController : MonoBehaviour
{
    public static CartFaseController Instance { get; private set; }

    [SerializeField] Deck _deck;
    [SerializeField] Hand _hand;
    [SerializeField] Graveyard _graveyard;

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

    public void CartFaseStarting()
    {
        NewTurn();
    }

    void NewTurn()
    {
        int currentHandCarts = _hand.CurrentHand;
        List<Cart> carts = _deck.NewTurn(currentHandCarts);
        _hand.NewTurn(carts);
    }

    public void SelectionDone(List<Cart> selectedCarts)
    {
        GeneralController.Instance.CartFaseDone(selectedCarts);
    }
}
