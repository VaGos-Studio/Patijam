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
            _hand.Clear(); // Limpiar _hand antes de añadir nuevas cartas
            _hand.AddRange(list);
        }

        if (_hand.Count > 0)
        {
            SelectCards();
        }
        else
        {
            SelectionDone();
        }
    }

    void SelectCards()
    {
        HashSet<int> selectedIndices = new();

        int TotalCards = Random.Range(1, 4);
        while (selectedIndices.Count < TotalCards && selectedIndices.Count < _hand.Count)
        {
            int cardNum = Random.Range(0, _hand.Count);
            if (selectedIndices.Add(cardNum))
            {
                _cardSelected.Add(cardNum);
            }
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
