using UnityEngine;
using UnityEngine.UI;

public class End_UI : MonoBehaviour
{
    [SerializeField] Button _goMainMenuButton;

    private void Awake()
    {
        _goMainMenuButton.onClick.AddListener(GoMainMenu);
    }
    public void GoMainMenu()
    {
        ChangeSceneController.Instance.AutoLoadScene(0);
    }
}
