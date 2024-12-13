using System;

public static class Mystery
{
    public static void Execute()
    {
        int enumCount = Enum.GetValues(typeof(CARDACTIONS)).Length;
        Random random = new Random();
        int selected = random.Next(1, 16);
        ActionFaseController.Instance.ExecuteSpecialAction((CARDACTIONS)selected);
    }
}
