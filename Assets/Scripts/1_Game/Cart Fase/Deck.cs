using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    List<Card> _deck = new();
    [SerializeField] SO_Cards SO_Cards;

    private void Awake()
    {
        foreach (var c in SO_Cards.Cards)
        {
            Card cart = new();
            cart.SpecialAction = c.SpecialAction;
            cart.CardText = c.CardText;
            _deck.Add(cart);
        }

        _deck = _deck.OrderBy(x => Random.value).ToList();
    }

    public List<Card> NewTurn(int currentHand)
    {
        int numToSend = 1 + (5 - currentHand);

        List<Card> sentTohand = new();
        if (numToSend > 1)
        {
            for (int i = _deck.Count - 1; i > _deck.Count - numToSend; i--)
            {
                sentTohand.Add(_deck[i]);
            }
            int from = _deck.Count - sentTohand.Count;
            int to = sentTohand.Count;
            _deck.RemoveRange(from, to);
        }

        return sentTohand;
    }
}
