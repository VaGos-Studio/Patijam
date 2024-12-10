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

    public void NextLevel()
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
            ChangeSceneController.Instance.ReLoadScene();
        }
        else
        {
            TheOneController.Instance.RestartPos();
            GameStateEvent.OnChangeState(GAMESTATE.CARD_FASE);
        }
        //Restar part
    }

    public void Goal()
    {
        if (WinOrLoseController.Instance.IsWin())
        {
            TimerEvent.OnStopTimer();
            GameStateEvent.OnNextLevel();
        }
        else
        {
            ActionFaseController.Instance.ActionFaseDone();
        }
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
}
