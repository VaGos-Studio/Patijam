using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinOrLoseController : MonoBehaviour
{
    public static WinOrLoseController Instance { get; private set; }

    int _underworldPoints = 0;
    int _skyPoints = 0;
    public int SKyPoints { get { return _skyPoints; } }

    [SerializeField] int _pointsToLose = 0;
    [SerializeField] int _pointsToWin = 0;
    [SerializeField] TMP_Text _underworldPontText;
    [SerializeField] GameObject _winPanel;
    [SerializeField] GameObject _losePanel;

    bool _win = false;
    bool _lose = false;

    public int SkyPoints { get { return _skyPoints; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _underworldPontText.text = $"Inframundo: {_underworldPoints}";
            _winPanel.SetActive(false);
            _losePanel.SetActive(false);
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

    public bool IsWin()
    {
        _skyPoints++;
        //show progress
        if (_skyPoints >= _pointsToWin)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void WinLevel()
    {
        if (!_win)
        {
            _winPanel.SetActive(true);
            StartCoroutine(Win());
            _win = true;
        }
    }
    IEnumerator Win()
    {
        //ParticleSystem particle = _winPanel.GetComponentInChildren<ParticleSystem>();
        //particle.Play();
        Slider bar = _winPanel.GetComponentInChildren<Slider>();
        TMP_Text barText = bar.GetComponentInChildren<TMP_Text>();
        LeanTween.cancel(gameObject);
        LeanTween.value(0, 1, 4).setOnUpdate(val => bar.value = val);
        yield return new WaitForSeconds(1);
        barText.text = $"3";
        yield return new WaitForSeconds(1);
        barText.text = $"2";
        yield return new WaitForSeconds(1);
        barText.text = $"1";
        yield return new WaitForSeconds(1);
        barText.text = $"0";
        GeneralController.Instance.NextLevel();
    }

    public void LoseLevel()
    {
        if (!_lose)
        {
            _losePanel.SetActive(true);
            StartCoroutine(Lose());
            _lose = true;
        }
    }

    IEnumerator Lose()
    {
        //ParticleSystem particle = _losePanel.GetComponentInChildren<ParticleSystem>();
        //particle.Play();
        Slider bar = _losePanel.GetComponentInChildren<Slider>();
        TMP_Text barText = bar.GetComponentInChildren<TMP_Text>();
        LeanTween.cancel(gameObject);
        LeanTween.value(0, 1, 4).setOnUpdate(val => bar.value = val);
        yield return new WaitForSeconds(1);
        barText.text = $"3";
        yield return new WaitForSeconds(1);
        barText.text = $"2";
        yield return new WaitForSeconds(1);
        barText.text = $"1";
        yield return new WaitForSeconds(1);
        barText.text = $"0";
        GeneralController.Instance.RepeatLevel();
    }
}
