using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    List<SpriteRenderer> _floors = new();
    List<BoxCollider2D> _collider = new();

    private void Awake()
    {
        SpriteRenderer[] floors = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer item in floors)
        {
            _floors.Add(item);
            _collider.Add(item.GetComponent<BoxCollider2D>());
        }
    }

    public void SetSprites(Sprite[] sprites)
    {
        foreach (SpriteRenderer item in _floors)
        {
            int selected = Random.Range(0, sprites.Length);
            item.sprite = sprites[selected];
        }
    }

    public void SetFloor(List<int> config)
    {
        for (int i = 0; i < _floors.Count; i++)
        {
            switch (config[i])
            {
                case 0:
                    _floors[i].gameObject.SetActive(false);
                    _collider[i].enabled = false;
                    break;
                case 1:
                    _floors[i].gameObject.SetActive(true);
                    _collider[i].enabled = true;
                    break;
                default:
                    break;
            }
        }
    }

    public void Flip()
    {
        _floors.Reverse();
        for (int i = 0; i < _floors.Count; i++)
        {
            _floors[i].transform.localPosition = new Vector3(i + 0.5f, -0.5f, 0);
        }
     }
}
