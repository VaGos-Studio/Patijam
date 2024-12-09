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
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] Button _EndLoadingButton;

    private void Start()
    {
        _EndLoadingButton.onClick.AddListener(EndLoading);
        _EndLoadingButton.interactable = false;
        OnOff(false);
    }
    void EndLoading()
    {
        ChangeSceneController.Instance.AllowLoadedScene();
        OnOff(false);
        GameStateEvent.OnChangeState(GAMESTATE.STARTING);
        _EndLoadingButton.interactable = false;
    }

    public void OnOff(bool action)
    {
        gameObject.SetActive(action);
    }

    public void TurnOnButton()
    {
        _EndLoadingButton.interactable = true;
    }
}
