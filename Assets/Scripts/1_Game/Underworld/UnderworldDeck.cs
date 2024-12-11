using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnderworldDeck
{
    List<UnderworldCard> _deck = new();
    SO_UnderworldCards _SO_UnderworldCards;

    public UnderworldDeck(SO_UnderworldCards SO_UnderworldCards)
    {
        _SO_UnderworldCards = SO_UnderworldCards;

        foreach (var c in _SO_UnderworldCards.Cards)
        {
            UnderworldCard cart = new();
            cart.UnderworldAction = c.UnderworldAction;
            cart.CardText = c.CardText;
            _deck.Add(cart);
        }

        _deck = _deck.OrderBy(x => Random.value).ToList();
    }

    public List<UnderworldCard> NewTurn(int currentHand)
    {
        int numToSend = 1 + (5 - currentHand);

        List<UnderworldCard> sentTohand = new();
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
