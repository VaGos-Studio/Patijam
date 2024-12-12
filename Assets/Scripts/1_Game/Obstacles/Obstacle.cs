using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    internal float XPos = 0;
    [SerializeField] GameObject _groundObstacleSensor;
    [SerializeField] GameObject _airObstacleSensor;
    [SerializeField] SO_Obstacle _SO_Obstacle;
    SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
        _sprite.enabled = true;
    }

    public void SetConfig(int config)
    {
        LeanTween.cancel(gameObject);
        _airObstacleSensor.SetActive(false);
        _groundObstacleSensor.SetActive(false);

        switch (config)
        {
            case -1:
                break;
            case 0:
                gameObject.SetActive(false);
                transform.localPosition = new Vector3(XPos, 0, 0);
                break;
            case 1:
                transform.localPosition = new Vector3(XPos, 0, 0);
                SetGround();
                break;
            case 2:
                transform.localPosition = new Vector3(XPos, 1, 0);
                LeanTween.value(0, 2, 2).setOnUpdate(val =>
                    transform.localPosition = new Vector3(XPos, val, 0));
                SetGround();
                break;
            case 3:
                transform.localPosition = new Vector3(XPos, 1, 0);
                SetAir();
                break;
            case 4:
                transform.localPosition = new Vector3(XPos, 1, 0);
                LeanTween.value(1, 3, 2).setOnUpdate(val =>
                    transform.localPosition = new Vector3(XPos, val, 0));
                SetAir();
                break;
            default:
                break;
        }
    }

    void SetGround()
    {
        var index = Random.Range(0, _SO_Obstacle.GroundSprite.Count);
        _sprite.sprite = _SO_Obstacle.GroundSprite[index];
        gameObject.SetActive(true);
        _groundObstacleSensor.SetActive(true);
    }

    void SetAir()
    {
        var index = Random.Range(0, _SO_Obstacle.AirSprite.Count);
        _sprite.sprite = _SO_Obstacle.AirSprite[index];
        gameObject.SetActive(true);
        _airObstacleSensor.SetActive(true);
    }
}
