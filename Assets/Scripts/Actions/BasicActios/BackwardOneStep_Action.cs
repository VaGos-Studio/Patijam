using System.Threading.Tasks;

public static class BackwardOneStep_Action
{
    public static async Task Execute()
    {
        ActionFaseController.Instance.SetDelay(1);
        await Task.Delay(0);
        TheOneController.Instance.MoveBackward(1);
    }
}
