using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    List<Cart> _hand = new();
    [HideInInspector] public int CurrentHand { get { return _hand.Count; } }

    [SerializeField] Button _seleccionDoneButton;
    [SerializeField] Button[] _cartButtons;
    
    TMP_Text[] _cartTexts;
    List<int> _cartSelected = new();

    private void Awake()
    {
        _cartTexts = new TMP_Text[_cartButtons.Length];
        for (int i = 0; i < _cartButtons.Length; i++)
        {
            _cartTexts[i] = _cartButtons[i].GetComponentInChildren<TMP_Text>();
            int num = i;
            _cartButtons[i].onClick.AddListener(() => SelectCart(num));
        }

        _seleccionDoneButton.onClick.AddListener(SelectionDone);
    }

    public void NewTurn(List<Cart> list)
    {
        foreach (Cart c in list)
        {
            _hand.Add(c);
        }

        foreach (TMP_Text text in _cartTexts)
        {
            text.text = string.Empty;
        }

        foreach (Button button in _cartButtons)
        {
            button.gameObject.SetActive(false);
        }

        for (int i = 0; i < _hand.Count; i++)
        {
            _cartTexts[i].text = _hand[i].CartText;
            _cartButtons[i].gameObject.SetActive(true);
        }
    }

    void SelectCart(int cartNum)
    {
        bool isSelected = false;
        if (_cartSelected.Count > 0)
        {
            foreach (int item in _cartSelected)
            {
                if (cartNum == item)
                {
                    LeanTween.value(_cartButtons[cartNum].transform.localPosition.y, 0, 0.15f).setOnUpdate(val =>
                        _cartButtons[cartNum].transform.localPosition = new Vector3(_cartButtons[cartNum].transform.localPosition.x, val, 0));
                    _cartSelected.Remove(item);
                    isSelected = true;
                    break;
                }
            }
        }

        if (!isSelected)
        {
            _cartSelected.Add(cartNum);
            LeanTween.value(_cartButtons[cartNum].transform.localPosition.y, 50, 0.15f).setOnUpdate(val =>
                _cartButtons[cartNum].transform.localPosition = new Vector3(_cartButtons[cartNum].transform.localPosition.x, val, 0));
        }
    }

    void SelectionDone()
    {
        List<Cart> selectedCarts = new();
        foreach (int item in _cartSelected)
        {
            selectedCarts.Add(_hand[item]);
        }
        CartFaseController.Instance.SelectionDone(selectedCarts);
    }
}
