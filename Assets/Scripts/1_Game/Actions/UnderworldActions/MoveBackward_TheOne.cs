using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

public static class MoveBackward_TheOne
{
#if !UNITY_WEBGL
    public static async Task Execute()
    {
        ActionFaseController.Instance.SetDelay(0.5f);
        TheOneController.Instance.MoveBackward(1);
        await Task.Delay(500);
        TheOneController.Instance.SetIdel();
    }
#endif
#if UNITY_WEBGL
    public static IEnumerator Execute()
    {
        ActionFaseController.Instance.SetDelay(0.5f);
        TheOneController.Instance.MoveBackward(1);
        yield return new WaitForSeconds(0.5f);
        TheOneController.Instance.SetIdel();
    }
#endif
}
