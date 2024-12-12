public class ActionSelector
{
    public void ExecuteBasicAction(BASICACTION basicAction)
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

    public void ExecuteSpecialAction(SPECIALACTION specialAction)
    {
        switch (specialAction)
        {
            case SPECIALACTION.NONE:
                break;
            case SPECIALACTION.NEXTHAND:
                Change_NextHand.Execute();
                break;
            case SPECIALACTION.ENVIRAN:
                Change_Enviroment_Random.Execute();
                break;
            case SPECIALACTION.OBSRAN:
                Change_Obstacle_Random.Execute();
                break;
            case SPECIALACTION.DFAL2:
                DontFall_2.Execute();
                break;
            case SPECIALACTION.DFAL4_BAR1:
                DontFall_4_Back_1.Execute();
                break;
            case SPECIALACTION.DFALPLUS:
                DontFall_All.Execute();
                break;
            case SPECIALACTION.FAR3:
                Forward_3.Execute();
                break;
            case SPECIALACTION.DOUJUMP:
                JumpDouble.Execute();
                break;
            case SPECIALACTION.DOUJUMP_FAR2:
                JumpDouble_Forwar_2.Execute();
                break;
            case SPECIALACTION.FY23:
                Fly_2_3Times.Execute();
                break;
            case SPECIALACTION.FY21:
                Fly_2_Once.Execute();
                break;
            case SPECIALACTION.INMOBS:
                Inmune_1_Obstacle.Execute();
                break;
            case SPECIALACTION.INMOBSPLUS:
                Inmute_All.Execute();
                break;
            case SPECIALACTION.REJUMP:
                Restore_Jump.Execute();
                break;
            case SPECIALACTION.MYSTERY:
                Mystery.Execute();
                break;
        }
        ActionFaseController.Instance.ActionStarted();
    }
}
