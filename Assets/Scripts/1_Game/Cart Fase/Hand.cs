using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public List<Card> _hand = new();
    [HideInInspector] public int CurrentHand { get { return _hand.Count; } }

    [SerializeField] Button _seleccionDoneButton;
    [SerializeField] Button[] _cardButtons;

    List<List<TMP_Text>> _cardTexts = new();
    public List<int> _cardSelected = new();

    private void Awake()
    {
        for (int i = 0; i < _cardButtons.Length; i++)
        {
            TMP_Text[] textsArray = new TMP_Text[2];
            textsArray = _cardButtons[i].GetComponentsInChildren<TMP_Text>();
            List<TMP_Text> texts = new()
            {
                textsArray[0],
                textsArray[1]
            };
            _cardTexts.Add(texts);
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

        foreach (List<TMP_Text> text in _cardTexts)
        {
            text[0].text = string.Empty;
            text[1].text = string.Empty;
        }

        foreach (Button button in _cardButtons)
        {
            button.gameObject.SetActive(false);
            LeanTween.value(button.transform.localPosition.y, -269, 0.15f).setOnUpdate(val =>
                button.transform.localPosition = new Vector3(button.transform.localPosition.x, val, 0));
        }

        for (int i = 0; i < _hand.Count; i++)
        {
            _cardTexts[i][0].text = _hand[i].CardAction.ToString();
            _cardTexts[i][1].text = _hand[i].CardText;
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
                    LeanTween.value(_cardButtons[cartNum].transform.localPosition.y, -269, 0.15f).setOnUpdate(val =>
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
            LeanTween.value(_cardButtons[cartNum].transform.localPosition.y, -219, 0.15f).setOnUpdate(val =>
                _cardButtons[cartNum].transform.localPosition = new Vector3(_cardButtons[cartNum].transform.localPosition.x, val, 0));
        }

        if (_cardSelected.Count != 0)
        {
            _seleccionDoneButton.interactable = true;
        }        
        else
        {
            _seleccionDoneButton.interactable = false;
        }

        if (_cardSelected.Count >= 3)
        {
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
        _cardSelected.Sort((a, b) => b.CompareTo(a));
        foreach (int item in _cardSelected)
        {
            _hand.RemoveAt(item);
        }
    }

    public List<Card> ReturnHand()
    {
        List<Card> toReturn = new();
        foreach (Card item in _hand)
        {
            toReturn.Add(item);
        }
        _hand.Clear();
        return toReturn;
    }
}
