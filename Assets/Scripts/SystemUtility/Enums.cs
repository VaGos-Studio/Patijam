using UnityEngine;

public class Enums : MonoBehaviour
{
}

public enum GAMESTATE
{
    MENU,
    LOADING,
    STARTING,
    CARD_FASE,
    UNDERWORLD_FASE,
    ACTION_FASE,
    WIN,
    LOSE,
    PAUSE,
    TIME_OVER
}

public enum BASICACTION
{
    NONE,
    FORWARD_ONE_STEP,
    BACKWARD_ONE_STEP,
    JUMP_ONE_STEP
}

//public enum SPECIALACTION
//{
//    NONE,
//    NEXTHAND,
//    ENVIRAN,
//    OBSRAN,
//    DFAL2,
//    DFAL4_BAR1,
//    DFALPLUS,
//    FAR3,
//    DOUJUMP,
//    DOUJUMP_FAR2,
//    FY23,
//    FY21,
//    INMOBS,
//    INMOBSPLUS,
//    REJUMP,
//    MYSTERY
//}

//public enum UNDERWORLDACTION
//{
//    NONE,
//    ENVIRAN,
//    DELCENT3,
//    DELRAN5,
//    DELEA2,
//    FLIENV,
//    ADOBSAI2578,
//    ADOBSOR1469,
//    ADOBSOR369,
//    ADOBSMOAI,
//    ADOBSMOOR,
//    DELONKIL,
//    DELINM,
//    BARON,
//    PENOMBRA,
//    UNDMYS,
//    NEXTHAND
//}

public enum CARDACTIONS
{
    NONE,
    //1 Player
    OBSRAN,
    DFAL2,
    DFAL4_BAR1,
    DFALPLUS,
    FAR3,
    DOUJUMP,
    DOUJUMP_FAR2,
    FY23,
    FY21,
    INMOBS,
    INMOBSPLUS,
    REJUMP,
    MYSTERY,
    NEXTHAND,
    ENVIRAN,
    //15 Underworld
    DELCENT3,
    DELRAN5,
    DELEA2,
    FLIENV,
    ADOBSAI2578,
    ADOBSOR1469,
    ADOBSOR369,
    ADOBSMOAI,
    ADOBSMOOR,
    DELONKIL,
    DELINM,
    BARON,
    PENOMBRA,
    UNDMYS
}
