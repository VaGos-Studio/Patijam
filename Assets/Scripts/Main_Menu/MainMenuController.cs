using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController Instance { get; private set; }

    [SerializeField] MainMenu_UI _mainMenu_UI;

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
    }
    #endregion
}
