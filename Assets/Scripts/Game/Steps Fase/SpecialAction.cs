using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAction : MonoBehaviour
{
    Button _button;

    [SerializeField] SPECIALACTION _specialAction;
    string _cartText = string.Empty;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ExecuteAction);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    void ExecuteAction()
    {
        ActionSelector.ExecuteSpecialAction(_specialAction);
        _button.interactable = false;
    }

    public void ResertActionNum(Card cart)
    {
        _specialAction = cart.SpecialAction;
        _cartText = cart.CardText;
        _button.interactable = true;
    }
}
