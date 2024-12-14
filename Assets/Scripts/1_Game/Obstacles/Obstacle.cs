using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    internal float XPos = 0;
    [SerializeField] GameObject _groundObstacleSensor;
    [SerializeField] GameObject _airObstacleSensor;
    [SerializeField] SO_Obstacle _SO_Obstacle;
    [SerializeField] SpriteRenderer _sprite;

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
                SetGround();
                break;
            case 2:
                transform.localPosition = new Vector3(XPos, 1.5f, 0);
                LeanTween.value(0.5f, 2.5f, 2).setLoopPingPong().setOnUpdate(val =>
                    transform.localPosition = new Vector3(XPos, val, 0));
                SetGround();
                break;
            case 3:
                transform.localPosition = new Vector3(XPos, 1.5f, 0);
                SetAir();
                break;
            case 4:
                transform.localPosition = new Vector3(XPos, 1, 0);
                LeanTween.value(1.5f, 3.5f, 2).setLoopPingPong().setOnUpdate(val =>
                    transform.localPosition = new Vector3(XPos, val, 0));
                SetAir();
                break;
            default:
                if (_sprite.sprite == null)
                {
                    gameObject.SetActive(false);
                }
                break;
        }
    }

    void SetGround()
    {
        var index = Random.Range(0, _SO_Obstacle.GroundSprite.Count);
        _sprite.sprite = _SO_Obstacle.GroundSprite[index];
        _groundObstacleSensor.SetActive(true);
    }

    void SetAir()
    {
        var index = Random.Range(0, _SO_Obstacle.AirSprite.Count);
        _sprite.sprite = _SO_Obstacle.AirSprite[index];
        _airObstacleSensor.SetActive(true);
    }
}
