using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck
{
    List<Card> _deck = new();
    SO_Deck SO_Deck;

    public Deck(SO_Deck underworldDeck)
    {
        SO_Deck = underworldDeck;

        foreach (var c in SO_Deck.Cards)
        {
            Card cart = new();
            cart.CardAction = c.CardAction;
            cart.CardText = c.CardText;
            _deck.Add(cart);
        }

        _deck = _deck.OrderBy(x => Random.value).ToList();
    }

    public List<Card> NewTurn(int currentHand)
    {
        int startAt = _deck.Count - 1;
        int numToSend = 5 - currentHand;
        if (_deck.Count > 0 && numToSend > 0)
        {
            if (_deck.Count < numToSend)
            {
                numToSend = _deck.Count;
            }

            List<Card> sentTohand = new();
            for (int i = startAt; i > startAt - numToSend; i--)
            {
                sentTohand.Add(_deck[i]);
            }
            int from = _deck.Count - sentTohand.Count;
            int to = sentTohand.Count;
            _deck.RemoveRange(from, to);

            return sentTohand;
        }
        else
        {
            List<Card> sentTohand = new();
            return sentTohand;
        }
    }

    public void ReturnHand(List<Card> toreturn)
    {
        foreach (Card card in toreturn)
        {
            _deck.Add(card);
        }
    }
}
