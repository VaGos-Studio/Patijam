using System.Threading.Tasks;

public static class JumpOneStep_Action
{
    public static async Task Execute()
    {
        ActionFaseController.Instance.SetDelay(1.5f);
        TheOneController.Instance.MoveUpward(1);
        await Task.Delay(250);
        TheOneController.Instance.MoveForward(2);
        await Task.Delay(1000);
        TheOneController.Instance.MoveDownward(1);
    }
}
