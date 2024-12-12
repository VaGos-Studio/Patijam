using System.Threading.Tasks;

public static class DontFall_2
{
    public static async Task Execute()
    {
        TheOneController.Instance.CanFall(false);
        ActionFaseController.Instance.SetDelay(1f);
        TheOneController.Instance.MoveForward(2);
        await Task.Delay(1000);
        TheOneController.Instance.CanFall(true);
    }
}