using System.Threading.Tasks;
using UnityEngine;
using System.Collections;

public static class JumpOneStep_Action
{
#if !UNITY_WEBGL
    public static async Task Execute()
    {
        ActionFaseController.Instance.SetDelay(1.5f);
        TheOneController.Instance.MoveUpward(1);
        await Task.Delay(250);
        TheOneController.Instance.MoveForward(2);
        await Task.Delay(1000);
        TheOneController.Instance.MoveDownward(1);
    }
#endif
#if UNITY_WEBGL
    public static IEnumerator Execute()
    {
        ActionFaseController.Instance.SetDelay(1.5f);
        TheOneController.Instance.MoveUpward(1);
        yield return new WaitForSeconds(0.25f);
        TheOneController.Instance.MoveForward(2);
        yield return new WaitForSeconds(1f);
        TheOneController.Instance.MoveDownward(1);
    }
#endif
}
