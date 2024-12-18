using UnityEngine.Events;

public static class GameStateEvent
{
    public static event UnityAction<GAMESTATE> ChangeState;
    public static void OnChangeState(GAMESTATE newState)
    {
        ChangeState?.Invoke(newState);
    }
}
