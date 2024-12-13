using System.Collections.Generic;
public static class Add_Obstacle_Air_2578
{
    public static void Execute()
    {
        List<int> config = new List<int>()
        {
            -1,
            3,
            -1,
            -1,
            3,
            -1,
            3,
            3,
            -1
        };
        ObstaclesController.Instance.SetObstacles(config);
    }
}
