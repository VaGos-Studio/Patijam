using System.Collections.Generic;
public static class Add_Obstacle_Floor_369
{
    public static void Execute()
    {
        List<int> config = new List<int>()
        {
            -1,
            -1,
            3,
            -1,
            -1,
            3,
            -1,
            -1,
            3,
        };
        ObstaclesController.Instance.SetObstacles(config);
    }
}
