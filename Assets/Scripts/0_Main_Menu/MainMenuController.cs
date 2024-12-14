using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController Instance { get; private set; }

    [SerializeField] MainMenu_UI _mainMenu_UI;
    [SerializeField] Credits_UI _credits_UI;

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

    #region Main Menu
    public void LetsPlay(int scenenum)
    {
        ChangeSceneController.Instance.LoadScene(scenenum);
        LeanTween.cancelAll();
    }
    #endregion

    public void ManagePanels(GameObject panel)
    {
        _mainMenu_UI.gameObject.SetActive(true);
        _credits_UI.gameObject.SetActive(true);
        panel.SetActive(false);
    }
}
