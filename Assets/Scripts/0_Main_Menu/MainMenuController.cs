using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController Instance { get; private set; }

    [SerializeField] MainMenu_UI _mainMenu_UI;
    [SerializeField] Credits_UI _credits_UI;
    [SerializeField] Instruction_UI _instruction_UI;
    [SerializeField] Cards_UI _cards_UI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            GameStateEvent.OnChangeState(GAMESTATE.MENU);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AudioController.Instance.SetSoundtrack(0);
    }

    #region Main Menu
    public void LetsPlay(int scenenum)
    {
        ChangeSceneController.Instance.LoadScene(scenenum);
        LeanTween.cancelAll();
    }
    #endregion

    public void BackMainMenu(GameObject panel)
    {
        _mainMenu_UI.gameObject.SetActive(true);
        panel.SetActive(false);
    }

    public void OpenCreditsPanel()
    {
        _mainMenu_UI.gameObject.SetActive(false);
        _credits_UI.gameObject.SetActive(true);
    }

    public void OpenInstructionPanel()
    {
        _mainMenu_UI.gameObject.SetActive(false);
        _instruction_UI.gameObject.SetActive(true);
    }

    public void OpenCardsPanel()
    {
        _mainMenu_UI.gameObject.SetActive(false);
        _cards_UI.gameObject.SetActive(true);
    }
}
