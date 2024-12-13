using UnityEngine;

public class UnderworldActionSelector
{
    public void ExecuteUnderworldAction(CARDACTIONS underworldAction)
    {
        switch (underworldAction)
        {
            case CARDACTIONS.NONE:
                break;
            case CARDACTIONS.ENVIRAN:
                Change_Enviroment_Random.Execute();
                break;
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
            case CARDACTIONS.NEXTHAND:
                Change_NextHand.Execute();
                break;
            default:
                break;
        }
    }
}
