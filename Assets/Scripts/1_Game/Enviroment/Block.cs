using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    List<SpriteRenderer> _floors = new();

    private void Awake()
    {
        SpriteRenderer[] floors = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer item in floors)
        {
            _floors.Add(item);
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
                    break;
                case 1:
                    _floors[i].gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }

    public void Flip()
    {
        _floors.Reverse();
     }
}
