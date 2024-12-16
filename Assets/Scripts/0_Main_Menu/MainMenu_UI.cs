using UnityEngine;
using UnityEngine.UI;

public class MainMenu_UI : MonoBehaviour
{
    [SerializeField] Button _playButton;
    [SerializeField] Button _creditsButton;
    [SerializeField] Button _instructionsButton;
    [SerializeField] Button _cardsButton;
    [SerializeField] Button _instagramButton;
    [SerializeField] Button _xButton;

    private void Awake()
    {
        _playButton.onClick.AddListener(PlayGame);
        _playButton.onClick.AddListener(() => AudioController.Instance.SetUI(0));
        _creditsButton.onClick.AddListener(OpenCredits);
        _creditsButton.onClick.AddListener(() => AudioController.Instance.SetUI(0));
        _instructionsButton.onClick.AddListener(OpenInstruction);
        _instructionsButton.onClick.AddListener(() => AudioController.Instance.SetUI(0));
        _cardsButton.onClick.AddListener(OpenCards);
        _cardsButton.onClick.AddListener(() => AudioController.Instance.SetUI(0));
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
        MainMenuController.Instance.OpenCreditsPanel();
    }

    void OpenInstruction()
    {
        MainMenuController.Instance.OpenInstructionPanel();
    }

    void OpenCards()
    {
        MainMenuController.Instance.OpenCardsPanel();
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
