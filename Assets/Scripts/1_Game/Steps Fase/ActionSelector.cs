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
            //Underworld
            case CARDACTIONS.DELCENT3:
                Delete_3_Center_Floors.Execute();
                break;
            case CARDACTIONS.DELRAN5:
                Delete_5_Random_Floors.Execute();
                break;
            case CARDACTIONS.DELEA2:
                Delete_each_2_Floors.Execute();
                break;
            case CARDACTIONS.FLIENV:
                Flip_Enviroment.Execute();
                break;
            case CARDACTIONS.ADOBSAI2578:
                Add_Obstacle_Air_2578.Execute();
                break;
            case CARDACTIONS.ADOBSOR1469:
                Add_Obstacle_Floor_1469.Execute();
                break;
            case CARDACTIONS.ADOBSOR369:
                Add_Obstacle_Floor_369.Execute();
                break;
            case CARDACTIONS.ADOBSMOAI:
                Add_Obstacle_Movil_Air.Execute();
                break;
            case CARDACTIONS.ADOBSMOOR:
                Add_Obstacle_Movil_Floor.Execute();
                break;
            case CARDACTIONS.DELONKIL:
                Delete_1_TheOneSkill.Execute();
                break;
            case CARDACTIONS.DELINM:
                Delete_InmuneSkill.Execute();
                break;
            case CARDACTIONS.BARON:
                MoveBackward_TheOne.Execute();
                break;
            case CARDACTIONS.PENOMBRA:
                Penombra.Execute();
                break;
            case CARDACTIONS.UNDMYS:
                Underworld_Mystery.Execute();
                break;
        }
        ActionFaseController.Instance.ActionStarted();
    }
}
