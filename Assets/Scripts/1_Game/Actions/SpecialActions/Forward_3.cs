using System.Threading.Tasks;

public static class Forward_3
{
    public static async Task Execute()
    {
        ActionFaseController.Instance.SetDelay(1.5f);
        TheOneController.Instance.MoveForward(3);
        await Task.Delay(1500);
    }
}