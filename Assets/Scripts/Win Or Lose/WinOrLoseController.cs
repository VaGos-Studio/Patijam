using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinOrLoseController : MonoBehaviour
{
    public static WinOrLoseController Instance { get; private set; }

    int _underworldPoints = 0;

    [SerializeField] int _pointsToLose = 0;
    [SerializeField] TMP_Text _underworldPontText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _underworldPontText.text = $"Inframundo: {_underworldPoints}";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsLost()
    {
        _underworldPoints++;
        _underworldPontText.text = $"Inframundo: {_underworldPoints}";
        if (_underworldPoints >= _pointsToLose)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
