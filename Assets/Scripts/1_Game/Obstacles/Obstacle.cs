using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float XPos = 0;
    [SerializeField] GameObject _groundObstacleSensor;
    [SerializeField] GameObject _airObstacleSensor;
    [SerializeField] Animator _animator;

    bool _isAnimated = false;

    public void SetConfig(int config)
    {
        LeanTween.cancel(gameObject);
        _airObstacleSensor.SetActive(false);
        _groundObstacleSensor.SetActive(false);
        gameObject.SetActive(true);

        switch (config)
        {
            case 0:
                gameObject.SetActive(false);
                transform.localPosition = new Vector3(XPos, 0.5f, 0);
                break;
            case 1:
                transform.localPosition = new Vector3(XPos, 0.5f, 0);
                _animator.Play("Pyke1");
                SetGround();
                break;
            case 2:
                transform.localPosition = new Vector3(XPos, 0.5f, 0);
                _animator.Play("Pyke2");
                SetGround();
                break;
            case 3:
                transform.localPosition = new Vector3(XPos, 1.5f, 0);
                SetAir();
                break;
            case 4:
                transform.localPosition = new Vector3(XPos, 1.5f, 0);
                LeanTween.value(1.5f, 3.5f, 2).setLoopPingPong().setOnUpdate(val =>
                    transform.localPosition = new Vector3(XPos, val, 0));
                SetAir();
                break;
            default:
                if (!_isAnimated)
                {
                    gameObject.SetActive(false);
                }
                break;
        }
    }

    void SetGround()
    {        
        _groundObstacleSensor.SetActive(true);
        _isAnimated = true;
    }

    void SetAir()
    {
        _animator.Play("Plague");
        _airObstacleSensor.SetActive(true);
        _isAnimated = true;
    }
}
