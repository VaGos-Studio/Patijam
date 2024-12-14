using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    public static ObstaclesController Instance { get; private set; }

    [SerializeField] List<Obstacle> _obstacles = new();
    List<int> startConfig = new List<int>(9) { 0, 0, 0, 0, 0, 0, 0, 0, 0};

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            for (int i = 0; i < _obstacles.Count; i++)
            {
                int index = i;
                _obstacles[i].XPos = index + 1.5f;
            }
            SetObstacles(startConfig);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NewTurn()
    {
        SetObstacles(startConfig);
    }

    public void SetObstacles(List<int> config)
    {
        for (int i = 0; i < _obstacles.Count; i++)
        {
            _obstacles[i].SetConfig(config[i]);
        }
    }

    public void TurnObstacleOff(string name)
    {
        foreach (Obstacle item in _obstacles)
        {
            if (item.name == name)
            {
                item.gameObject.SetActive(false);
            }
        }
    }
}
