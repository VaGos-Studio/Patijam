using System.Collections.Generic;
public static class Delete_3_Center_Floors
{
    public static void Execute()
    {
        List<int> config = new List<int>()
        {
            1,
            -1,
            -1,
            -1,
            0,
            0,
            0,
            -1,
            -1,
            1
        };
        EnviromentController.Instance.SetBlockConfig(config);
    }
}
