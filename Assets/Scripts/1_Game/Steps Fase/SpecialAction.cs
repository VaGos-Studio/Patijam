using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAction : MonoBehaviour
{
    Button _button;
    TMP_Text _buttonText;

    [SerializeField] SPECIALACTION _specialAction;
    string _cartText = string.Empty;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _buttonText = GetComponentInChildren<TMP_Text>();
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
        ActionFaseController.Instance.ExecuteSpecialAction(_specialAction);
        _button.interactable = false;
    }

    public void ResertActionNum(Card cart)
    {
        _specialAction = cart.SpecialAction;
        _cartText = cart.CardText;
        _buttonText.text = _specialAction.ToString();
        if (_specialAction == SPECIALACTION.NONE)
        {
            _button.interactable = false;
        }
        else
        {
            _button.interactable = true;
        }
    }
}
