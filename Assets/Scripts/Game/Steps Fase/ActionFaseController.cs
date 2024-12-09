using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFaseController : MonoBehaviour
{
    public static ActionFaseController Instance { get; private set; }

    [SerializeField] CanvasGroup _actionCanvasGroup;
    [SerializeField] GameObject _preventClickPanel;
    BasicAction[] _basicActioButtons;
    SpecialAction[] _specialActioButtons;
    float _delay = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _preventClickPanel.SetActive(false);
            _basicActioButtons = GetComponentsInChildren<BasicAction>();
            _specialActioButtons = GetComponentsInChildren<SpecialAction>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _actionCanvasGroup.gameObject.SetActive(false);
    }

    public void SetDelay(float delay)
    {
        _delay = delay;
    }

    public void ActionFaseStarting(List<Cart> list)
    {
        _actionCanvasGroup.gameObject.SetActive(true);
        Starting(list);
    }

    void Starting(List<Cart> list)
    {
        foreach (var item in _basicActioButtons)
        {
            item.ResertActionNum();
        }

        for (int i = 0; i < _specialActioButtons.Length; i++)
        {
            if (_specialActioButtons[i] != null)
            {
                if (list[i] != null)
                {
                    _specialActioButtons[i].ResertActionNum(list[i]);
                }
                else
                {
                    Cart item = new();
                    _specialActioButtons[i].ResertActionNum(item);
                }
            }
        }
    }

    public void ActionStarted()
    {
        _preventClickPanel.SetActive(true);
        LeanTween.cancel(gameObject);
        StartCoroutine(HideButtons(_delay));
    }

    IEnumerator HideButtons(float delay)
    {
        LeanTween.value(1, 0, 0.25f).setOnUpdate(val =>
            _actionCanvasGroup.alpha = val);
        yield return new WaitForSeconds(delay);
        ActionFinished();
    }

    void ActionFinished()
    {
        if (GeneralController.Instance.TheOneIsGrounded())
        {
            StartCoroutine(ShowButtons());
        }
    }

    IEnumerator ShowButtons()
    {

        LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
            _actionCanvasGroup.alpha = val);
        yield return new WaitForSeconds(0.25f);
        _preventClickPanel.SetActive(false);
    }

    public void TheOneDied()
    {
        StopCoroutine(HideButtons(0));
    }
}
