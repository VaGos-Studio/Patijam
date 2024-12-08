using UnityEngine;
using UnityEngine.UI;

public class BasicAction : MonoBehaviour
{
    Button _button;
    int _currentActionNum = 0;

    [SerializeField] int _totalActionNum = 0;
    [SerializeField] BASICACTION _basicAction;

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
            ActionSelector.ExecuteBasicAction(_basicAction);
            _currentActionNum--;
            if (_currentActionNum == 0)
            {
                _button.interactable = false;
            }
        }
    }

    public void ResertActionNum()
    {
        _currentActionNum = _totalActionNum;
        _button.interactable = true;
    }
}
