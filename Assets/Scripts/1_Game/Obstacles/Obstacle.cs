using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float XPos = 0;
    [SerializeField] Animator _animator;
    [SerializeField] AudioClip[] _clips;
    [SerializeField] AudioSource _source;

    bool _isAnimated = false;

    public void SetConfig(int config)
    {
        LeanTween.cancel(gameObject);
        gameObject.SetActive(true);

        switch (config)
        {
            case 0:
                gameObject.SetActive(false);
                transform.localPosition = new Vector3(XPos, 0.5f, 0);
                _animator.SetTrigger("Exit");
                break;
            case 1:
                transform.localPosition = new Vector3(XPos, 0.5f, 0);
                _animator.Play("Pyke1");
                _isAnimated = true;
                break;
            case 2:
                transform.localPosition = new Vector3(XPos, 0.5f, 0);
                _animator.Play("Pyke2");
                _isAnimated = true;
                break;
            case 3:
                transform.localPosition = new Vector3(XPos, 1.5f, 0);
                _animator.Play("Plague");

                _isAnimated = true;
                break;
            case 4:
                transform.localPosition = new Vector3(XPos, 1.5f, 0);
                LeanTween.value(1.5f, 3.5f, 2).setLoopPingPong().setOnUpdate(val =>
                    transform.localPosition = new Vector3(XPos, val, 0));
                _animator.Play("Plague");

                _isAnimated = true;
                break;
            default:
                if (!_isAnimated)
                {
                    gameObject.SetActive(false);
                }
                break;
        }
    }

    void SetAudio(int clip)
    {
        _source.PlayOneShot(_clips[clip]);
    }
}
