using System.Threading.Tasks;
public static class DontFall_4_Back_1
{
    public static async Task Execute()
    {
        TheOneController.Instance.CanFall(false);
        ActionFaseController.Instance.SetDelay(2.5f);
        TheOneController.Instance.MoveForward(4);
        await Task.Delay(2000);
        TheOneController.Instance.CanFall(true);
        TheOneController.Instance.MoveBackward(1);
    }
}