using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }

    [Header("UI")]
    [SerializeField] AudioSource _uiAudioSource;
    [SerializeField] AudioClip[] _uiClips;

    [Header("SFX")]
    [SerializeField] AudioSource _sfxAudioSource;
    [SerializeField] AudioClip[] _sfxClips;

    [Header("Soundtrack")]
    [SerializeField] AudioSource _soundtrackAudioSource;
    [SerializeField] AudioClip[] _soundtrackClips; //0 = menu, 1 = loading, 2 >= niveles

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

    public void SetUI(int ui)
    {
        _uiAudioSource.PlayOneShot(_uiClips[ui]);
    }

    public void SetSFX(int sfx)
    {
        _sfxAudioSource.PlayOneShot(_sfxClips[sfx]);
    }

    public void SetSoundtrack(int  soundtrack)
    {
        _soundtrackAudioSource.clip = _soundtrackClips[soundtrack];
        _soundtrackAudioSource.Play();
    }

}
