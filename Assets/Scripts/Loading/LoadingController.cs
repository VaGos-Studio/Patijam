using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    public static LoadingController Instance { get; private set; }

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

    [SerializeField] Button _endLoadingButton;
    TMP_Text _endLoadingText;

    private void Start()
    {
        _endLoadingButton.onClick.AddListener(EndLoading);
        _endLoadingButton.onClick.AddListener(() => AudioController.Instance.SetUI(0));
        _endLoadingButton.interactable = false;
        _endLoadingText = _endLoadingButton.GetComponentInChildren<TMP_Text>();
        OnOff(false);
    }
    void EndLoading()
    {
        ChangeSceneController.Instance.AllowLoadedScene();
        OnOff(false);
        GameStateEvent.OnChangeState(GAMESTATE.STARTING);
        _endLoadingButton.interactable = false;
    }

    public void OnOff(bool action)
    {
        gameObject.SetActive(action);
    }

    IEnumerator Loading()
    {
        while (!_endLoadingButton.interactable)
        {
            _endLoadingText.text = $"";
            yield return new WaitForSeconds(0.25f);
            _endLoadingText.text = $"Cargando.";
            yield return new WaitForSeconds(0.25f);
            _endLoadingText.text = $"Cargando..";
            yield return new WaitForSeconds(0.25f);
            _endLoadingText.text = $"Cargando...";
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void TurnOnButton()
    {
        _endLoadingButton.interactable = true;
        _endLoadingText.text = $"¡Jugar!";
    }

    public void LoadingText(float progress)
    {
        _endLoadingText.text = $"Cargando {progress}%";
    }
}
