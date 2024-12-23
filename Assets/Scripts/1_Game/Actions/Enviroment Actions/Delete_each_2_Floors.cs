using System.Collections.Generic;
public static class Delete_each_2_Floors
{
    public static void Execute()
    {
        List<int> config = new List<int>() { 1, 0, -1, 0, -1, 0, -1, 0, -1, 1 };
        EnviromentController.Instance.SetBlockConfig(config);
    }
}
