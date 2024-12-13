using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFaseController : MonoBehaviour
{
    public static ActionFaseController Instance { get; private set; }

    [SerializeField] CanvasGroup _actionCanvasGroup;
    [SerializeField] GameObject _preventClickPanel;
    [SerializeField] GameObject _GoalDetector;
    BasicAction[] _basicActioButtons;
    SpecialAction[] _specialActioButtons;
    ActionSelector _actionSelector = new();
    float _delay = 1;
    int _removeSkill = -1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _preventClickPanel.SetActive(false);
            _basicActioButtons = FindObjectsOfType<BasicAction>();
            _specialActioButtons = FindObjectsOfType<SpecialAction>();
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

    public void ActionFaseStarting(List<Card> list)
    {
        _actionCanvasGroup.gameObject.SetActive(true);
        LeanTween.cancel(gameObject);
        LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
            _actionCanvasGroup.alpha = val);
        Starting(list);
    }

    void Starting(List<Card> list)
    {
        foreach (var item in _basicActioButtons)
        {
            item.ResertActionNum();
        }

        if (list.Count > 0)
        {
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
                        Card item = new();
                        _specialActioButtons[i].ResertActionNum(item);
                    }
                    _specialActioButtons[i].gameObject.SetActive(true);
                    if (_removeSkill == i)
                    {
                        _specialActioButtons[i].gameObject.SetActive(false);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < _specialActioButtons.Length; i++)
            {
                if (_specialActioButtons[i] != null)
                {
                    _specialActioButtons[i].gameObject.SetActive(false);
                }
            }
        }
    }

    public void ActionStarted()
    {
        _preventClickPanel.SetActive(true);
        StartCoroutine(HideButtons(_delay));
    }

    IEnumerator HideButtons(float delay)
    {
        LeanTween.cancel(gameObject);
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
        else
        {
            GeneralController.Instance.ActionFaseInterrupted();
            _actionCanvasGroup.gameObject.SetActive(false);
            _preventClickPanel.SetActive(false);
        }
    }

    IEnumerator ShowButtons()
    {
        LeanTween.cancel(gameObject);
        LeanTween.value(0, 1, 0.25f).setOnUpdate(val =>
            _actionCanvasGroup.alpha = val);
        yield return new WaitForSeconds(0.25f);
        _preventClickPanel.SetActive(false);
    }

    public void TheOneDied()
    {
        StopCoroutine(HideButtons(0));
    }

    public void ActionFaseDone()
    {
        GeneralController.Instance.ActionFaseDone();
        Vector3 newPos = _GoalDetector.transform.position;
        newPos.x += 10;
        _GoalDetector.transform.position = newPos;
        _actionCanvasGroup.gameObject.SetActive(false);
        _preventClickPanel.SetActive(false);
        _removeSkill = -1;
    }

    public void QuickActionFase()
    {
        StartCoroutine(QuickAction());
    }

    IEnumerator QuickAction()
    {
        do
        {
            ExecuteBasicAction(BASICACTION.FORWARD_ONE_STEP);
            yield return new WaitForSeconds(1.15f);
        }
        while (GameStateController.Instance.CurrentState == GAMESTATE.TIME_OVER);
    }

    public void ExecuteBasicAction(BASICACTION basicAction)
    {
        _actionSelector.ExecuteBasicAction(basicAction);
    }

    public void ExecuteSpecialAction(CARDACTIONS cardAction)
    {
        _actionSelector.ExecuteSpecialAction(cardAction);
    }

    public void RestoreJump()
    {
        foreach (BasicAction item in _basicActioButtons)
        {
            if (item.gameObject.name == "Jump Action Button")
            {
                item.ResertActionNum();
            }
        }
    }

    public void RemoveOneSkill()
    {
        int selected = Random.Range(0, 3);
        _removeSkill = selected;
    }
}
