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

    public void ExecuteSpecialAction(CARDACTIONS cardAction)
    {
        switch (cardAction)
        {
            case CARDACTIONS.NONE:
                break;
            case CARDACTIONS.NEXTHAND:
                Change_NextHand.Execute();
                break;
            case CARDACTIONS.ENVIRAN:
                Change_Enviroment_Random.Execute();
                break;
            case CARDACTIONS.OBSRAN:
                Change_Obstacle_Random.Execute();
                break;
            case CARDACTIONS.DFAL2:
                DontFall_2.Execute();
                break;
            case CARDACTIONS.DFAL4_BAR1:
                DontFall_4_Back_1.Execute();
                break;
            case CARDACTIONS.DFALPLUS:
                DontFall_All.Execute();
                break;
            case CARDACTIONS.FAR3:
                Forward_3.Execute();
                break;
            case CARDACTIONS.DOUJUMP:
                JumpDouble.Execute();
                break;
            case CARDACTIONS.DOUJUMP_FAR2:
                JumpDouble_Forwar_2.Execute();
                break;
            case CARDACTIONS.FY23:
                Fly_2_3Times.Execute();
                break;
            case CARDACTIONS.FY21:
                Fly_2_Once.Execute();
                break;
            case CARDACTIONS.INMOBS:
                Inmune_1_Obstacle.Execute();
                break;
            case CARDACTIONS.INMOBSPLUS:
                Inmute_All.Execute();
                break;
            case CARDACTIONS.REJUMP:
                Restore_Jump.Execute();
                break;
            case CARDACTIONS.MYSTERY:
                Mystery.Execute();
                break;
        }
        ActionFaseController.Instance.ActionStarted();
    }
}
