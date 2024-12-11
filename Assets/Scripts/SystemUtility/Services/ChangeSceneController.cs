using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneController : MonoBehaviour
{
    public static ChangeSceneController Instance { get; private set; }

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

    private AsyncOperation _asyncOperation;


    public void LoadScene(int sceneIndex)
    {
        LoadingController.Instance.OnOff(true);
        GameStateEvent.OnChangeState(GAMESTATE.LOADING);
        StartCoroutine(LoadSceneAsyncProcess(sceneIndex));
    }
    IEnumerator LoadSceneAsyncProcess(int sceneIndex)
    {
        if (_asyncOperation != null)
        {
            _asyncOperation = null;
        }

        // Begin to load the Scene you have specified.
        _asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

        // Don't let the Scene activate until you allow it to.
        _asyncOperation.allowSceneActivation = false;
        bool buttonactived = false;
        while (!_asyncOperation.isDone)
        {
            if (!buttonactived)
            {
                if (_asyncOperation.progress >= 0.9f)
                {
                    LoadingController.Instance.TurnOnButton();
                    buttonactived = true;
                }
                else
                {
                    LoadingController.Instance.LoadingText(_asyncOperation.progress);
                }
            }
            yield return null;
        }
    }

    public void AutoLoadScene(int sceneIndex)
    {
        LoadingController.Instance.OnOff(true);
        GameStateEvent.OnChangeState(GAMESTATE.LOADING);
        StartCoroutine(AutoLoadSceneAsyncProcess(sceneIndex));
    }
    IEnumerator AutoLoadSceneAsyncProcess(int sceneIndex)
    {
        if (_asyncOperation != null)
        {
            _asyncOperation = null;
        }

        // Begin to load the Scene you have specified.
        _asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

        // Don't let the Scene activate until you allow it to.
        _asyncOperation.allowSceneActivation = true;

        while (!_asyncOperation.isDone)
        {
            //Debug.Log($"[scene]:{sceneIndex} [load progress]: {_asyncOperation.progress}");
            yield return null;
        }
    }

    public void ReLoadScene()
    {
        LoadingController.Instance.OnOff(true);
        GameStateEvent.OnChangeState(GAMESTATE.LOADING);
        StartCoroutine(ReLoadSceneAsyncProcess());
    }
    IEnumerator ReLoadSceneAsyncProcess()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if (_asyncOperation != null)
        {
            _asyncOperation = null;
        }

        // Begin to load the Scene you have specified.
        _asyncOperation = SceneManager.LoadSceneAsync(index);

        // Don't let the Scene activate until you allow it to.
        _asyncOperation.allowSceneActivation = false;

        bool buttonactived = false;
        while (!_asyncOperation.isDone)
        {
            if (!buttonactived)
            {
                if (_asyncOperation.progress >= 0.9f)
                {
                    LoadingController.Instance.TurnOnButton();
                    buttonactived = true;
                }
                else
                {
                    LoadingController.Instance.LoadingText(_asyncOperation.progress);
                }
            }
            yield return null;
        }
    }

    public void AllowLoadedScene()
    {
        Debug.Log("Allowed Scene Activation in coroutinemanager");
        _asyncOperation.allowSceneActivation = true;
    }
}
