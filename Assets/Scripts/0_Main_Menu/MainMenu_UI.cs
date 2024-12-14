using UnityEngine;
using UnityEngine.UI;

public class MainMenu_UI : MonoBehaviour
{
    [SerializeField] Button _playButton;
    [SerializeField] Button _creditsButton;
    [SerializeField] Button _instagramButton;
    [SerializeField] Button _xButton;

    private void Awake()
    {
        _playButton.onClick.AddListener(PlayGame);
        _creditsButton.onClick.AddListener(OpenCredits);
        _instagramButton.onClick.AddListener(OpenInstagram);
        _xButton.onClick.AddListener(OpenX);
    }
    void PlayGame()
    {
        MainMenuController.Instance.LetsPlay(1);
        gameObject.SetActive(false);
    }

    void OpenCredits()
    {
        MainMenuController.Instance.ManagePanels(gameObject);
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
