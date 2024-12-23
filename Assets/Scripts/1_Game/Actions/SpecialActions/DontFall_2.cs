using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

public static class DontFall_2
{
#if !UNITY_WEBGL
    public static async Task Execute()
    {
        TheOneController.Instance.CanFall(false);
        ActionFaseController.Instance.SetDelay(1f);
        TheOneController.Instance.MoveForward(2);
        await Task.Delay(1000);
        TheOneController.Instance.CanFall(true);
    }
#endif
#if UNITY_WEBGL
    public static IEnumerator Execute()
    {
        TheOneController.Instance.CanFall(false);
        ActionFaseController.Instance.SetDelay(1f);
        TheOneController.Instance.MoveForward(2);
        yield return new WaitForSeconds(1f);
        TheOneController.Instance.CanFall(true);
    }
#endif
}