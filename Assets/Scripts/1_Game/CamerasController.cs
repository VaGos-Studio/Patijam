using Cinemachine;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    public static CamerasController Instance { get; private set; }

    [SerializeField] CinemachineVirtualCamera _actionCam;
    [SerializeField] CinemachineVirtualCamera _cardCam;

    Animator _animator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _animator = GetComponent<Animator>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void IntroDone()
    {
        GeneralController.Instance.IntroDone();
    }
    
    public void StartIntro()
    {
        _animator.Play("Intro");
    }

    public void SetActionCam()
    {
        _actionCam.Priority = 2;
        _cardCam.Priority = 1;
    }

    public void SetCardCam()
    {
        _cardCam.Priority = 2;
        _actionCam.Priority = 1;
    }

    public void MoveCardCam()
    {
        LeanTween.cancel(gameObject);
        int newPos = (int)(_cardCam.transform.position.x + 10);
        LeanTween.value(_cardCam.transform.position.x, newPos, 0.25f).setOnUpdate(val =>
            _cardCam.transform.position = new Vector3(val, _cardCam.transform.position.y, _cardCam.transform.position.z));
    }
}
