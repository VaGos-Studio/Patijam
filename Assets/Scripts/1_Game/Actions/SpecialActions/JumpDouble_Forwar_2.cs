using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public static class JumpDouble_Forwar_2
{
#if !UNITY_WEBGL
    public static async Task Execute()
    {
        ActionFaseController.Instance.SetDelay(3f);
        TheOneController.Instance.MoveUpward(1);
        await Task.Delay(250);
        TheOneController.Instance.MoveForward(3);
        await Task.Delay(1500);
        TheOneController.Instance.MoveDownward(1);
        await Task.Delay(250);
        TheOneController.Instance.MoveForward(2);
    }
#endif
#if UNITY_WEBGL
    public static IEnumerator Execute()
    {
        ActionFaseController.Instance.SetDelay(3f);
        TheOneController.Instance.MoveUpward(1);
        yield return new WaitForSeconds(0.25f);
        TheOneController.Instance.MoveForward(3);
        yield return new WaitForSeconds(1.5f);
        TheOneController.Instance.MoveDownward(1);
        yield return new WaitForSeconds(0.25f);
        TheOneController.Instance.MoveForward(2);

    }
#endif
}