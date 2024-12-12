using System.Threading.Tasks;

public static class JumpDouble
{
    public static async Task Execute()
    {
        ActionFaseController.Instance.SetDelay(2f);
        TheOneController.Instance.MoveUpward(1);
        await Task.Delay(250);
        TheOneController.Instance.MoveForward(3);
        await Task.Delay(1500);
        TheOneController.Instance.MoveDownward(1);
    }
}
