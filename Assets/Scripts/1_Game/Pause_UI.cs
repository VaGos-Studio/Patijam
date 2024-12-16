using UnityEngine;
using UnityEngine.UI;

public class Pause_UI : MonoBehaviour
{
    [SerializeField] GameObject _pausePanel;
    [SerializeField] Button _pauseButton;
    [SerializeField] Button _resumeButton;
    [SerializeField] Button _goMainMenuButton;
    [SerializeField] GameObject _GoMAinMenuPanel;
    [SerializeField] Button _yesButton;
    [SerializeField] Button _noButton;

    private void Awake()
    {
        _pausePanel.SetActive(false);
        _pauseButton.onClick.AddListener(Pause);
        _pauseButton.onClick.AddListener(() => AudioController.Instance.SetUI(0));
        _resumeButton.onClick.AddListener(Resume);
        _goMainMenuButton.onClick.AddListener(GoMainMenu);
        _goMainMenuButton.onClick.AddListener(() => AudioController.Instance.SetUI(0));
        _GoMAinMenuPanel.SetActive(false);
        _yesButton.onClick.AddListener(Yes);
        _yesButton.onClick.AddListener(() => AudioController.Instance.SetUI(0));
        _noButton.onClick.AddListener(No);
        _noButton.onClick.AddListener(() => AudioController.Instance.SetUI(0));
    }

    void Pause()
    {
        if (GameStateController.Instance.CurrentState == GAMESTATE.CARD_FASE || GameStateController.Instance.CurrentState == GAMESTATE.ACTION_FASE)
        {
            GeneralController.Instance.OnPausePress();
            _pausePanel.SetActive(true);
        }
    }

    void Resume()
    {
        GeneralController.Instance.OnResumePress();
        _GoMAinMenuPanel.SetActive(false);
        _pausePanel.SetActive(false);
    }

    void GoMainMenu()
    {
        _GoMAinMenuPanel.SetActive(true);
    }

    void Yes()
    {
        ChangeSceneController.Instance.AutoLoadScene(0);
    }

    void No()
    {
        _GoMAinMenuPanel.SetActive(false);
    }
}
