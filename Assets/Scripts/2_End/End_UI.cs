using UnityEngine;
using UnityEngine.UI;

public class End_UI : MonoBehaviour
{
    [SerializeField] Button _goMainMenuButton;
    [SerializeField] Button _instagramButton;
    [SerializeField] Button _xButton;

    private void Awake()
    {
        _goMainMenuButton.onClick.AddListener(GoMainMenu);
        _goMainMenuButton.onClick.AddListener(() => AudioController.Instance.SetUI(0));
        _instagramButton.onClick.AddListener(OpenInstagram);
        _xButton.onClick.AddListener(OpenX);
    }
    public void GoMainMenu()
    {
        ChangeSceneController.Instance.AutoLoadScene(0);
    }

    void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/vagos_studio/?hl=en");
    }

    void OpenX()
    {
        Application.OpenURL("https://x.com/vagos_studio");
    }
}
