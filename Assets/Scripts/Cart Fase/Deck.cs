using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    List<Cart> _deck = new();
    [SerializeField] SO_Carts SO_Carts;

    private void Awake()
    {
        foreach (var c in SO_Carts.Carts)
        {
            Cart cart = new();
            cart.SpecialAction = c.SpecialAction;
            cart.CartText = c.CartText;
            _deck.Add(cart);
        }

        _deck = _deck.OrderBy(x => Random.value).ToList();
    }

    public List<Cart> NewTurn(int currentHand)
    {
        int numToSend = 1 + (5 - currentHand);

        List<Cart> sentTohand = new();
        for (int i = _deck.Count - 1; i > _deck.Count - numToSend; i--)
        {
            sentTohand.Add(_deck[i]);
        }

       return sentTohand;
    }
}
