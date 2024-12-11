using System.Threading.Tasks;

public static class JumpOneStep_Action
{
    public static async Task Execute()
    {
        ActionFaseController.Instance.SetDelay(2f);
        await Task.Delay(0);
        TheOneController.Instance.MoveUpward(1);
        await Task.Delay(500);
        TheOneController.Instance.MoveForward(2);
        await Task.Delay(1000);
        TheOneController.Instance.MoveDownward(1);
    }
}
