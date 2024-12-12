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
            if (i == 0 || i == 9)
            {
                config.Add(1);
            }
            else
            {
                int state = random.Next(0, 3);
                if (i == 2)
                {
                    config.Add(state);
                }
                else
                {
                    if (config[i - 2] == config[i - 1] && config[i - 1] == state)
                    {
                        do
                        {
                            state = random.Next(0, 3);
                        }
                        while (state == config[i - 1]);
                    }
                    config.Add(state);
                }
            }
        }
        EnviromentController.Instance.SetBlockConfig(config);
    }
}