using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    List<Card> _hand = new();
    [HideInInspector] public int CurrentHand { get { return _hand.Count; } }

    [SerializeField] Button _seleccionDoneButton;
    [SerializeField] Button[] _cardButtons;

    TMP_Text[] _cardTexts;
    List<int> _cardSelected = new();

    private void Awake()
    {
        _cardTexts = new TMP_Text[_cardButtons.Length];
        for (int i = 0; i < _cardButtons.Length; i++)
        {
            _cardTexts[i] = _cardButtons[i].GetComponentInChildren<TMP_Text>();
            int num = i;
            _cardButtons[i].onClick.AddListener(() => SelectCart(num));
        }

        _seleccionDoneButton.onClick.AddListener(SelectionDone);
        _seleccionDoneButton.interactable = false;
    }

    public void NewTurn(List<Card> list)
    {
        _cardSelected.Clear();
        _seleccionDoneButton.interactable = false;

        if (list.Count > 0)
        {
            foreach (Card c in list)
            {
                _hand.Add(c);
            }
        }

        foreach (TMP_Text text in _cardTexts)
        {
            text.text = string.Empty;
        }

        foreach (Button button in _cardButtons)
        {
            button.gameObject.SetActive(false);
            LeanTween.value(button.transform.localPosition.y, 0, 0.15f).setOnUpdate(val =>
                button.transform.localPosition = new Vector3(button.transform.localPosition.x, val, 0));
        }

        for (int i = 0; i < _hand.Count; i++)
        {
            _cardTexts[i].text = _hand[i].CardText;
            _cardButtons[i].gameObject.SetActive(true);
            _cardButtons[i].interactable = true;
        }
    }

    void SelectCart(int cartNum)
    {
        bool isSelected = false;
        if (_cardSelected.Count > 0)
        {
            foreach (int item in _cardSelected)
            {
                if (cartNum == item)
                {
                    LeanTween.value(_cardButtons[cartNum].transform.localPosition.y, 0, 0.15f).setOnUpdate(val =>
                        _cardButtons[cartNum].transform.localPosition = new Vector3(_cardButtons[cartNum].transform.localPosition.x, val, 0));
                    _cardSelected.Remove(item);
                    isSelected = true;
                    break;
                }
            }
        }

        if (!isSelected)
        {
            _cardSelected.Add(cartNum);
            LeanTween.value(_cardButtons[cartNum].transform.localPosition.y, 50, 0.15f).setOnUpdate(val =>
                _cardButtons[cartNum].transform.localPosition = new Vector3(_cardButtons[cartNum].transform.localPosition.x, val, 0));
        }

        if (_cardSelected.Count >= 3)
        {
            _seleccionDoneButton.interactable = true;
            foreach (Button button in _cardButtons)
            {
                button.interactable = false;
            }

            foreach (int item in _cardSelected)
            {
                _cardButtons[item].interactable = true;
            }
        }
        else
        {
            _seleccionDoneButton.interactable = false;
            foreach (Button button in _cardButtons)
            {
                button.interactable = true;
            }
        }
    }

    void SelectionDone()
    {
        List<Card> selectedCarts = new();
        foreach (int item in _cardSelected)
        {
            selectedCarts.Add(_hand[item]);
        }
        CardFaseController.Instance.SelectionDone(selectedCarts);
    }
}
