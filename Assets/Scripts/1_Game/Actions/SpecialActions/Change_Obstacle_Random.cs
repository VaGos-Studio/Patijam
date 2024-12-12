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
            if (i == 0 || i == 1)
            {
                config.Add(state);
            }
            else
            {
                if (config[i - 2] == config[i - 1] && config[i - 1] == state)
                {
                    do
                    {
                        state = random.Next(-1, 5);
                    }
                    while (state == config[i - 1]);
                }
                config.Add(state);
            }
        }
        ObstaclesController.Instance.SetObstacles(config);
    }
}