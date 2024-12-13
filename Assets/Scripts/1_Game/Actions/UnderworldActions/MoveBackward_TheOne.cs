public static class MoveBackward_TheOne
{
    public static void Execute()
    {
        ActionFaseController.Instance.SetDelay(0.5f);
        TheOneController.Instance.MoveBackward(1);
    }
}
