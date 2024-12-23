public static class ForwardOneStep_Action
{
    public static void Execute()
    {
        ActionFaseController.Instance.SetDelay(0.5f);
        TheOneController.Instance.MoveForward(1);
    }
    //public static async Task Execute()
    //{
    //    ActionFaseController.Instance.SetDelay(1);
    //    await Task.Delay(0);
    //    TheOneController.Instance.MoveForward(1);
    //}
//#if UNITY_WEBGL
//    public static IEnumerator Execute()
//    {
//        ActionFaseController.Instance.SetDelay(0.5f);
//        TheOneController.Instance.MoveForward(1);
//        yield return new WaitForSeconds(0f);
//    }
//#endif
}
