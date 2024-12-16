using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAction : MonoBehaviour
{
    Button _button;
    TMP_Text _buttonText;

    [SerializeField] CARDACTIONS _cardAction;
    string _cartText = string.Empty;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _buttonText = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ExecuteAction);
        _button.onClick.AddListener(() => AudioController.Instance.SetUI(0));
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    void ExecuteAction()
    {
        ActionFaseController.Instance.ExecuteSpecialAction(_cardAction);
        _button.interactable = false;
    }

    public void ResertActionNum(Card cart)
    {
        _cardAction = cart.CardAction;
        _cartText = cart.CardText;
        _buttonText.text = _cardAction.ToString();
        if (_cardAction == CARDACTIONS.NONE)
        {
            _button.interactable = false;
        }
        else
        {
            _button.interactable = true;
        }
    }
}
