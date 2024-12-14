using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicAction : MonoBehaviour
{
    Button _button;
    int _currentActionNum = 0;

    [SerializeField] int _totalActionNum = 0;
    [SerializeField] BASICACTION _basicAction;
    [SerializeField] TMP_Text _actionText;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _currentActionNum = _totalActionNum;
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
        if (_currentActionNum > 0)
        {
            ActionFaseController.Instance.ExecuteBasicAction(_basicAction);
            _currentActionNum--;
            if (_actionText != null)
            {
                _actionText.text = $"{_currentActionNum}";
            }
            _actionText.text = $"{_currentActionNum}";
            if (_currentActionNum == 0)
            {
                _button.interactable = false;
            }
        }
    }

    public void ResertActionNum()
    {
        _currentActionNum = _totalActionNum;
        if (_actionText != null)
        {
            _actionText.text = $"{_currentActionNum}";
        }
        _button.interactable = true;
    }
}
