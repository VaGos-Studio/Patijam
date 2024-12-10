using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public static GameStateController Instance { get; private set; }

    [SerializeField] GAMESTATE _currentState = GAMESTATE.MENU;
    internal GAMESTATE CurrentState { get { return _currentState; } }

    int _currentLevel = 0;
    [SerializeField] int totalLevelnum = 1;
    internal int CurrentLevel {  get { return _currentLevel; } }

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
        GameStateEvent.NextLevel += NextLevel;
    }

    private void OnDisable()
    {
        GameStateEvent.ChangeState -= ChangeState;
        GameStateEvent.NextLevel -= NextLevel;
    }

    void ChangeState(GAMESTATE newState)
    {
        CheckStateForTimer(newState);
        IsTimeOver(newState);
        _currentState = newState;

        switch (_currentState)
        {
            case GAMESTATE.MENU:
                break;
            case GAMESTATE.LOADING:
                break;
            case GAMESTATE.STARTING:
                break;
            case GAMESTATE.CARD_FASE:
                GeneralController.Instance.CartFaseStarting();
                break;
            case GAMESTATE.UNDERWORLD_FASE:
                GeneralController.Instance.UnderwordActionFaseStarting();
                break;
            case GAMESTATE.ACTION_FASE:
                GeneralController.Instance.ActionFaseStarting();
                break;
            case GAMESTATE.WIN:
                break;
            case GAMESTATE.LOSE:
                break;
        }
    }

    void CheckStateForTimer(GAMESTATE newState)
    {
        if (newState == GAMESTATE.PAUSE)
        {
            if (_currentState == GAMESTATE.CARD_FASE || _currentState == GAMESTATE.ACTION_FASE)
            {
                GeneralController.Instance.OnPausePress();
            }
        }
        else if (newState == GAMESTATE.CARD_FASE || newState == GAMESTATE.ACTION_FASE)
        {
            if (_currentState == GAMESTATE.PAUSE)
            {
                GeneralController.Instance.OnResumePress();
            }
        }
    }

    void IsTimeOver(GAMESTATE newState)
    {
        if (newState == GAMESTATE.TIME_OVER)
        {
            if (_currentState == GAMESTATE.CARD_FASE)
            {
                GeneralController.Instance.QuickCardFase();
            }

            if (_currentState == GAMESTATE.ACTION_FASE)
            {
                GeneralController.Instance.QuickActionFase();
            }
        }
    }

    void NextLevel()
    {
        _currentLevel++;
        if (_currentLevel > totalLevelnum)
        {
            GeneralController.Instance.Gamecompleted();
        }
        else
        {
            GeneralController.Instance.NextLevel();
        }
    }
}
