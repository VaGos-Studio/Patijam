using System.Collections.Generic;
public static class Add_Obstacle_Floor_1469
{
    public static void Execute()
    {
        List<int> config = new List<int>()
        {
            1,
            -1,
            -1,
            1,
            -1,
            1,
            -1,
            -1,
            1,
        };
        ObstaclesController.Instance.SetObstacles(config);
    }
}
