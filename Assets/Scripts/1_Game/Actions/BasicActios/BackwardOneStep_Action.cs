using System.Threading.Tasks;

public static class BackwardOneStep_Action
{
    public static async Task Execute()
    {
        ActionFaseController.Instance.SetDelay(0.5f);
        TheOneController.Instance.MoveBackward(1);
    }
}
