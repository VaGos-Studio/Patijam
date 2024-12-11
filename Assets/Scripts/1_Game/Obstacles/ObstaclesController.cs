using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    public static ObstaclesController Instance { get; private set; }

    Obstacle[] _obstacles;
    List<int> startConfig = new List<int>(10) { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _obstacles = FindObjectsOfType<Obstacle>();
            for (int i = 0; i < _obstacles.Length; i++)
            {
                int index = i;
                _obstacles[i].XPos = index;
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
        for (int i = 0; i < _obstacles.Length; i++)
        {
            _obstacles[i].SetConfig(config[i]);
        }
    }
}
