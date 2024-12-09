using System;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] TMP_Text _timerText;
    float _time = 60f;
    bool _running = false;

    private void OnEnable()
    {
        TimerEvent.StartTimer += StartT;
        TimerEvent.StopTimer += StopT;
        TimerEvent.RestartTimer += RestartT;
    }
    private void OnDisable()
    {
        TimerEvent.StartTimer -= StartT;
        TimerEvent.StopTimer -= StopT;
        TimerEvent.RestartTimer -= RestartT;
    }

    void StartT()
    {
        _running = true;
    }

    void StopT()
    {
        _running = false;
    }

    void RestartT(float time)
    {
        _time = time;
        _running = true;
    }

    void Update()
    {
        if (!_running) { return; }
        if(_time <= 0) { return; }

        _time -= Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(_time);
        _timerText.text = timeSpan.ToString(format: @"mm\:ss\:ff");
        if (_time <= 0)
        {
            _timerText.text = $"Time Over";
            GeneralController.Instance.TimeOver();
        }

    }
}
