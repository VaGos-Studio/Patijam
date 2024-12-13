using System.Collections.Generic;
using UnityEngine;

public class UnderworldHand
{
    List<Card> _hand = new();
    [HideInInspector] public int CurrentHand { get { return _hand.Count; } }

    List<int> _cardSelected = new();

    public void NewTurn(List<Card> list)
    {
        _cardSelected.Clear();

        if (list.Count > 0)
        {
            foreach (Card c in list)
            {
                _hand.Add(c);
            }
        }

        SelectCards();
    }

    void SelectCards()
    {
        while (_cardSelected.Count < 3)
        {
            int cardNum = Random.Range(0, _hand.Count);
            _cardSelected.Add(cardNum);
        }

        SelectionDone();
    }

    void SelectionDone()
    {
        List<Card> selectedCarts = new();
        foreach (int item in _cardSelected)
        {
            selectedCarts.Add(_hand[item]);
        }
        UnderworldController.Instance.SelectionDone(selectedCarts);
        _cardSelected.Sort((a, b) => b.CompareTo(a));
        foreach (int item in _cardSelected)
        {
            _hand.RemoveAt(item);
        }
    }
}
