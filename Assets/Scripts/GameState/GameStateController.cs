using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public static GameStateController Instance { get; private set; }

    GAMESTATE _currentState = GAMESTATE.MENU;
    internal GAMESTATE CurrentState { get { return _currentState; } }

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

    private void OnEnable()
    {
        GameStateEvent.ChangeState += ChangeState;
    }

    private void OnDisable()
    {
        GameStateEvent.ChangeState -= ChangeState;
    }

    public void ChangeState(GAMESTATE newState)
    {
        CheckStateForTimer(newState);
        _currentState = newState;

        switch (_currentState)
        {
            case GAMESTATE.MENU:
                break;
            case GAMESTATE.LOADING:
                break;
            case GAMESTATE.STARTING:
                break;
            case GAMESTATE.CART_FASE:
                GeneralController.Instance.CartFaseStarting();
                break;
            case GAMESTATE.ACTION_FASE:
                GeneralController.Instance.ActionFaseStarting();
                break;
            case GAMESTATE.WIN:
                break;
            case GAMESTATE.LOSE:
                break;
            case GAMESTATE.TIME_OVER:
                break;
        }
    }

    void CheckStateForTimer(GAMESTATE newState)
    {
        if (newState == GAMESTATE.PAUSE)
        {
            if (_currentState == GAMESTATE.CART_FASE || _currentState == GAMESTATE.ACTION_FASE)
            {
                GeneralController.Instance.OnPausePress();
            }
        }
        else if (newState == GAMESTATE.CART_FASE || newState == GAMESTATE.ACTION_FASE)
        {
            if (_currentState == GAMESTATE.PAUSE)
            {
                GeneralController.Instance.OnResumePress();
            }
        }
    }
}
