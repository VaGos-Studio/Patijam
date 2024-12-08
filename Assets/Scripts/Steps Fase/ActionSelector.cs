public static class ActionSelector
{
    public static void ExecuteBasicAction(BASICACTION basicAction)
    {
        switch (basicAction)
        {
            case BASICACTION.FORWARD_ONE_STEP:
                ForwardOneStep_Action.Execute();
                break;
            case BASICACTION.BACKWARD_ONE_STEP:
                BackwardOneStep_Action.Execute();
                break;
            case BASICACTION.JUMP_ONE_STEP:
                JumpOneStep_Action.Execute();
                break;
        }
        ActionFaseController.Instance.ActionStarted();
    }

    public static void ExecuteSpecialAction(SPECIALACTION basicAction)
    {
        switch (basicAction)
        {
            case SPECIALACTION.POWER1:
                break;
            case SPECIALACTION.POWER2:
                break;
            case SPECIALACTION.POWER3:
                break;
        }
        ActionFaseController.Instance.ActionStarted();
    }
}
