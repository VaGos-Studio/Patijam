using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
public static class DontFall_4_Back_1
{
#if !UNITY_WEBGL
    public static async Task Execute()
    {
        TheOneController.Instance.CanFall(false);
        ActionFaseController.Instance.SetDelay(2.5f);
        TheOneController.Instance.MoveForward(4);
        await Task.Delay(2000);
        TheOneController.Instance.CanFall(true);
        TheOneController.Instance.MoveBackward(1);
    }
#endif
#if UNITY_WEBGL
    public static IEnumerator Execute()
    {
        TheOneController.Instance.CanFall(false);
        ActionFaseController.Instance.SetDelay(2.5f);
        TheOneController.Instance.MoveForward(4);
        yield return new WaitForSeconds(2f);
        TheOneController.Instance.CanFall(true);
        TheOneController.Instance.MoveBackward(1);
    }
#endif
}