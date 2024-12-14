using UnityEngine;
using UnityEngine.UI;

public class Credits_UI : MonoBehaviour
{
    [SerializeField] Button _backButton;
    [SerializeField] RectTransform _credits;
    [SerializeField] float _creditsTime;

    private void Awake()
    {
        _backButton.onClick.AddListener(BackMainMenu);
    }

    private void Start()
    {
        BackMainMenu();
    }

    public void BackMainMenu()
    {
        LeanTween.cancel(gameObject);
        MainMenuController.Instance.ManagePanels(gameObject);
    }

    private void OnEnable()
    {
        LeanTween.value(-2200, 1100, _creditsTime).setOnUpdate(val => _credits.localPosition = new Vector3(0, val, 0));
    }
}
