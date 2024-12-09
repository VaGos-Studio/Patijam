using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums : MonoBehaviour
{
}

public enum GAMESTATE
{
    MENU,
    LOADING,
    STARTING,
    CARD_FASE,
    ACTION_FASE,
    WIN,
    LOSE,
    PAUSE,
    TIME_OVER
}

public enum BASICACTION
{
    NONE,
    FORWARD_ONE_STEP,
    BACKWARD_ONE_STEP,
    JUMP_ONE_STEP
}

public enum SPECIALACTION
{
    NONE,
    POWER1,
    POWER2,
    POWER3
}
