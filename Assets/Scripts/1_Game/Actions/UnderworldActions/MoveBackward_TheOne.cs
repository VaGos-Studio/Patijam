

using System.Threading.Tasks;

public static class MoveBackward_TheOne
{
    public static async Task Execute()
    {
        ActionFaseController.Instance.SetDelay(0.5f);
        TheOneController.Instance.MoveBackward(1);
        await Task.Delay(500);
        TheOneController.Instance.SetIdel();
    }
}
