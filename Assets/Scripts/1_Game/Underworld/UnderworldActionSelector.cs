using UnityEngine;

public class UnderworldActionSelector
{
    public void ExecuteUnderworldAction(UNDERWORLDACTION underworldAction)
    {
        switch (underworldAction)
        {
            case UNDERWORLDACTION.POWER1:
                Debug.Log("accion ejecutada");
                break;
            case UNDERWORLDACTION.POWER2:
                Debug.Log("accion ejecutada");
                break;
            case UNDERWORLDACTION.POWER3:
                Debug.Log("accion ejecutada");
                break;
        }
    }
}
