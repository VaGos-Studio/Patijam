using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class TimerEvent
{
    public static event UnityAction StartTimer;
    public static event UnityAction StopTimer;
    public static event UnityAction<float> RestartTimer;

    public static void OnStartTimer()
    {
        StartTimer?.Invoke();
    }

    public static void OnStopTimer()
    {
        StopTimer?.Invoke();
    }

    public static void OnRestartTimer(float time)
    {
        RestartTimer?.Invoke(time);
    }
}
