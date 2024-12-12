using System;

public static class Mystery
{
    public static void Execute()
    {
        int enumCount = Enum.GetValues(typeof(SPECIALACTION)).Length;
        Random random = new Random();
        int selected = random.Next(0, enumCount);
        ActionFaseController.Instance.ExecuteSpecialAction((SPECIALACTION)selected);
    }
}
