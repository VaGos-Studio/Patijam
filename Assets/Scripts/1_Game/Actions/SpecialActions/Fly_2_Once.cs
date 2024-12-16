public static class Fly_2_Once
{
    public static void Execute()
    {
        TheOneController.Instance.SetFlyMove(2);
        ActionFaseController.Instance.SetDelay(0.5f);
        TheOneController.Instance.MoveUpward(2);
    }
}