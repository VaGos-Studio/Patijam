using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralController : MonoBehaviour
{
    public static GeneralController Instance { get; private set; }

    List<Cart> _selectedCarts = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GameStateEvent.OnChangeState(GAMESTATE.CART_FASE);
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
        ActionFaseController.Instance.ActionFaseStarting(_selectedCarts);
    }

    public void CartFaseStarting()
    {
        CartFaseController.Instance.CartFaseStarting();
    }
    #endregion

    #region Steps
    public void ActionFaseDone()
    {
        GameStateEvent.OnChangeState(GAMESTATE.ACTION_FASE);
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

    #region Cart Fase
    public void CartFaseDone(List<Cart> selectedCarts)
    {
        _selectedCarts = selectedCarts;
        GameStateEvent.OnChangeState(GAMESTATE.ACTION_FASE);
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
            GameStateEvent.OnChangeState(GAMESTATE.CART_FASE);
        }
        //Restar part
    }
    #endregion
}
