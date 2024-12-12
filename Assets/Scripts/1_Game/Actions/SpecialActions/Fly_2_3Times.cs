public static class Fly_2_3Times
{
    public static void Execute()
    {
        TheOneController.Instance.SetFlyMove(3);
        ActionFaseController.Instance.SetDelay(0.5f);
        TheOneController.Instance.MoveUpward(2);
    }
}