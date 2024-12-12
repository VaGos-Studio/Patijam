using UnityEngine;
using UnityEngine.UI;

public class MainMenu_UI : MonoBehaviour
{
    [SerializeField] Button _playButton;

    private void Awake()
    {
        _playButton.onClick.AddListener(PlayGame);
    }
    public void PlayGame()
    {
        MainMenuController.Instance.LetsPlay(1);
        gameObject.SetActive(false);
    }
}
