using System.Collections;
using System.Collections.Generic;
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

    [Header("The One")]
    [SerializeField] AudioSource _theOneAudioSource;
    [SerializeField] AudioClip[] _theOneClips;

    [Header("Soundtrack")]
    [SerializeField] AudioSource _soundtrackAudioSource;
    [SerializeField] AudioClip[] _soundtrackClips; //0 = menu, 1 = loading, 2 >= niveles

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

    private void Start()
    {
        SetSoundtrack(0);
    }

    public void SetUI(int ui)
    {
        _uiAudioSource.PlayOneShot(_uiClips[ui]);
    }

    public void SetSFX(int sfx)
    {
        _sfxAudioSource.PlayOneShot(_sfxClips[sfx]);
    }

    public void SetTheOne(int theOne)
    {
        _theOneAudioSource.PlayOneShot(_theOneClips[theOne]);
    }

    public void SetSoundtrack(int  soundtrack)
    {
        _soundtrackAudioSource.clip = _soundtrackClips[soundtrack];
    }

}
