using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralController : MonoBehaviour
{
    public static GeneralController Instance { get; private set; }

    List<Card> _selectedCards = new();

    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField] float CardTime = 1.0f;
    [SerializeField] float ActionTime = 1.0f;

    [Header("Testing")]
    [SerializeField] bool _isTesting = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _canvasGroup.alpha = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CamerasController.Instance.StartIntro();
    }

    private void OnDestroy()
    {
        LeanTween.cancelAll();
    }

    #region Timer
    public void TimeOver()
    {
        GameStateEvent.OnChangeState(GAMESTATE.TIME_OVER);
    }
    #endregion

    #region GameState
    public void OnPausePress()
    {
        TimerEvent.OnStopTimer();
    }

    public void OnResumePress()
    {
        TimerEvent.OnStartTimer();
    }

    public void ActionFaseStarting()
    {
        ActionFaseController.Instance.ActionFaseStarting(_selectedCards);
        TimerEvent.OnRestartTimer(ActionTime);
    }

    public void CartFaseStarting()
    {
        CardFaseController.Instance.CardFaseStarting();
        UnderworldController.Instance.UnderwordCardFaseStarting();
        ObstaclesController.Instance.NewTurn();
        TheOneController.Instance.NewTurn();
        TimerEvent.OnRestartTimer(CardTime);
    }

    public void UnderwordActionFaseStarting()
    {
        UnderworldController.Instance.UnderwordActionFaseStarting();
    }

    public void QuickCardFase()
    {
        CardFaseController.Instance.QuickCardFase();
    }

    public void QuickActionFase()
    {
        ActionFaseController.Instance.QuickActionFase();
    }

    public void WinLevel()
    {
        WinOrLoseController.Instance.WinLevel();
    }

    public void LoseLevel()
    {
        WinOrLoseController.Instance.LoseLevel();
    }

    public void NextLevel()
    {
        ChangeSceneController.Instance.ReLoadScene();
    }

    public void RepeatLevel()
    {
        ChangeSceneController.Instance.ReLoadScene();
    }

    public void Gamecompleted()
    {
        ChangeSceneController.Instance.AutoLoadScene(2);
    }
    #endregion

    #region Action
    public void ActionFaseDone()
    {
        TimerEvent.OnStopTimer();
        CamerasController.Instance.SetCardCam();
        CamerasController.Instance.MoveCardCam();
        StartCoroutine(ActionFaseDoneSteps());
    }

    IEnumerator ActionFaseDoneSteps()
    {
        LeanTween.cancel(gameObject);
        LeanTween.value(1, 0, 0.25f).setOnUpdate(val =>
            _canvasGroup.alpha = val);
        yield return new WaitForSeconds(0.25f);
        GameStateEvent.OnChangeState(GAMESTATE.CARD_FASE);
        LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
            _canvasGroup.alpha = val);
    }

    public void ActionFaseInterrupted()
    {
        TimerEvent.OnStopTimer();
        CamerasController.Instance.SetCardCam();
        ActionFaseController.Instance.TheOneDied();
        StartCoroutine(ActionFaseDoneSteps());
    }

    public bool TheOneIsGrounded()
    {
        if (!TheOneController.Instance.IsGrounded)
        {
            TheOneController.Instance.Die();
            return false;
        }
        else
        {
            return true;
        }
    }
    #endregion

    #region Card Fase
    public void CardFaseDone(List<Card> selectedCarts)
    {
        TimerEvent.OnStopTimer();
        _selectedCards = selectedCarts;
        StartCoroutine(CardFaseDoneSteps());
    }

    IEnumerator CardFaseDoneSteps()
    {
        LeanTween.cancel(gameObject);
        LeanTween.value(1, 0, 0.25f).setOnUpdate(val =>
            _canvasGroup.alpha = val);
        yield return new WaitForSeconds(0.25f);
        CamerasController.Instance.SetActionCam();
        yield return new WaitForSeconds(0.1f);
        GameStateEvent.OnChangeState(GAMESTATE.UNDERWORLD_FASE);
        LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
            _canvasGroup.alpha = val);
    }

    public void Penombra(bool action)
    {
        EnviromentController.Instance.Penombra(action);
    }
    #endregion

    #region Underworld
    public void UnderworldActionDone()
    {
        GameStateEvent.OnChangeState(GAMESTATE.ACTION_FASE);
    }
    #endregion

    #region TheOne
    public void TheOneDied()
    {
        TimerEvent.OnStopTimer();
        if (WinOrLoseController.Instance.IsLost())
        {
            TimerEvent.OnStopTimer();
            GameStateEvent.OnChangeState(GAMESTATE.LOSE);
        }
        else
        {
            ActionFaseController.Instance.TheOneDied();
        }
        //Restar part
    }

    public void Goal()
    {
        if (WinOrLoseController.Instance.IsWin())
        {
            TimerEvent.OnStopTimer();
            GameStateEvent.OnChangeState(GAMESTATE.WIN);
        }
        else
        {
            ActionFaseController.Instance.ActionFaseDone();
        }
    }

    public void TurnObstacleOff(string name)
    {
        ObstaclesController.Instance.TurnObstacleOff(name);
    }
    #endregion

    #region Camera
    public void IntroDone()
    {
        StartCoroutine(IntroDoneSteps());
    }

    IEnumerator IntroDoneSteps()
    {
        LeanTween.cancel(gameObject);
        yield return new WaitForSeconds(0.25f);
        GameStateEvent.OnChangeState(GAMESTATE.CARD_FASE);
        LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
            _canvasGroup.alpha = val);
    }
    #endregion

    #region Enviroment
    public int CurrentBlock()
    {
        return WinOrLoseController.Instance.SKyPoints;
    }
    #endregion
}
