using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralController : MonoBehaviour
{
    public static GeneralController Instance { get; private set; }

    List<Cart> _selectedCards = new();

    [SerializeField] CanvasGroup _canvasGroup;

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
        TimerEvent.OnRestartTimer(60);
    }

    public void CartFaseStarting()
    {
        CardFaseController.Instance.CartFaseStarting();
        TimerEvent.OnRestartTimer(60);
    }
    #endregion

    #region Action
    public void ActionFaseDone()
    {
        TimerEvent.OnStopTimer();
        StartCoroutine(ActionFaseDoneSteps());
    }

    IEnumerator ActionFaseDoneSteps()
    {
        LeanTween.value(1, 0, 0.25f).setOnUpdate(val =>
            _canvasGroup.alpha = val);
        yield return new WaitForSeconds(0.25f);
        CamerasController.Instance.SetCardCam();
        yield return new WaitForSeconds(0.1f);
        GameStateEvent.OnChangeState(GAMESTATE.CARD_FASE);
        LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
            _canvasGroup.alpha = val);
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
    public void CardFaseDone(List<Cart> selectedCarts)
    {
        TimerEvent.OnStopTimer();
        _selectedCards = selectedCarts;
        StartCoroutine(CardFaseDoneSteps());
    }

    IEnumerator CardFaseDoneSteps()
    {
        LeanTween.value(1, 0, 0.25f).setOnUpdate(val =>
            _canvasGroup.alpha = val);
        yield return new WaitForSeconds(0.25f);
        CamerasController.Instance.SetActionCam();
        yield return new WaitForSeconds(0.1f);
        GameStateEvent.OnChangeState(GAMESTATE.ACTION_FASE);
        LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
            _canvasGroup.alpha = val);
    }
    #endregion

    #region TheOne
    public void TheOneDied()
    {
        TimerEvent.OnStopTimer();
        if (WinOrLoseController.Instance.IsLost())
        {
        }
        else
        {
            TheOneController.Instance.RestartPos();
            GameStateEvent.OnChangeState(GAMESTATE.CARD_FASE);
        }
        //Restar part
    }
    #endregion

    #region Camera
    public void IntroDone()
    {
        StartCoroutine(IntroDoneSteps());
    }

    IEnumerator IntroDoneSteps()
    {
        LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
            _canvasGroup.alpha = val);
        yield return new WaitForSeconds(0.25f);
        GameStateEvent.OnChangeState(GAMESTATE.CARD_FASE);
        LeanTween.value(1, 0, 0.25f).setOnUpdate(val =>
            _canvasGroup.alpha = val);
    }
    #endregion
}
