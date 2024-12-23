using System.Collections.Generic;
using System;

public static class Add_Obstacle_Movil_Air
{
    public static void Execute()
    {
        Random random = new Random();
        List<int> config = new();

        for (int i = 0; i < 9; i++)
        {
            int state = random.Next(0, 2);
            if (i > 1 && config[i - 2] == config[i - 1] && config[i - 1] == state)
            {
                state = 1 - config[i - 1];
            }
            config.Add(state);
        }

        for (int i = 0; i < config.Count; i++)
        {
            if (config[i] == 0)
            {
                config[i] = random.Next(0, 2) == 0 ? -1 : 0;
            }
            else if (config[i] == 1)
            {
                config[i] = random.Next(0, 2) == 0 ? -1 : 4;
            }
        }

        ObstaclesController.Instance.SetObstacles(config);
    }
}
