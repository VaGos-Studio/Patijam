using System;
using System.Collections.Generic;

public static class Change_Obstacle_Random
{
    public static void Execute()
    {
        Random random = new Random();
        List<int> config = new();
        for (int i = 0; i < 9; i++)
        {
            int state = random.Next(-1, 5);
            if (i > 1 && config[i - 2] != 0 && config[i - 1] != 0 && state != 0)
            {
                config.Add(0);
            }
            else
            {
                config.Add(state);
            }

        }
        ObstaclesController.Instance.SetObstacles(config);
    }
}