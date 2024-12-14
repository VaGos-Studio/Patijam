using System;
using System.Collections.Generic;

public static class Change_Enviroment_Random
{
    public static void Execute()
    {
        Random random = new Random();
        List<int> config = new();
        for (int i = 0; i < 10; i++)
        {
            int state = random.Next(0, 3);
            if (i == 0 || i == 9)
            {
                config.Add(1);
            }
            else
            {
                if (i > 1 && config[i - 2] == config[i - 1] && config[i - 1] == state)
                {
                    state = 1 - config[i - 1];
                }
                config.Add(state);
            }
        }
        EnviromentController.Instance.SetBlockConfig(config);
    }
}