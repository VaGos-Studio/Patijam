using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Instruction_UI : MonoBehaviour
{
    [SerializeField] Sprite[] _instructionsSprite;
    [SerializeField] Image _currentInstructionImage;
    [SerializeField] Button _prevButton;
    [SerializeField] Button _nextButton;
    [SerializeField] Button _backButton;
    [SerializeField] TMP_Text _instructionText;

    [TextArea]
    [SerializeField] List<string> _instructionsTexts = new();

    int _currentInstruction = 0;

    private void Awake()
    {
        _prevButton.onClick.AddListener(Prev);
        _prevButton.onClick.AddListener(() => AudioController.Instance.SetUI(0));
        _nextButton.onClick.AddListener(Next);
        _nextButton.onClick.AddListener(() => AudioController.Instance.SetUI(0));
        _backButton.onClick.AddListener(BackMainMenu);
        _backButton.onClick.AddListener(() => AudioController.Instance.SetUI(0));

        _prevButton.interactable = false;
        _prevButton.gameObject.SetActive(false);
        _currentInstructionImage.sprite = _instructionsSprite[0];
        _instructionText.text = _instructionsTexts[0];

    }

    private void Start()
    {
        BackMainMenu();
    }

    void Prev()
    {
        _currentInstruction--;
        _currentInstructionImage.sprite = _instructionsSprite[_currentInstruction];
        _instructionText.text = _instructionsTexts[_currentInstruction];
        if (_currentInstruction == 0)
        {
            _prevButton.interactable = false;
            _prevButton.gameObject.SetActive(false);
        }

        if (_currentInstruction == _instructionsSprite.Length - 2)
        {
            _nextButton.interactable = true;
        }
    }

    void Next()
    {
        _currentInstruction++;
        _currentInstructionImage.sprite = _instructionsSprite[_currentInstruction];
        _instructionText.text = _instructionsTexts[_currentInstruction];
        if (_currentInstruction == _instructionsSprite.Length-1)
        {
            _nextButton.interactable = false;
        }

        if (_currentInstruction == 1)
        {
            _prevButton.interactable = true;
            _prevButton.gameObject.SetActive(true);
        }
    }

    public void BackMainMenu()
    {
        MainMenuController.Instance.BackMainMenu(gameObject);
    }
}
