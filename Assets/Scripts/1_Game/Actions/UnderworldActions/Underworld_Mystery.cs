using System;
public static class Underworld_Mystery
{
    public static void Execute()
    {
        int enumCount = Enum.GetValues(typeof(CARDACTIONS)).Length;
        Random random = new Random();
        int selected = random.Next(14, enumCount);
        UnderworldController.Instance.SetAction((CARDACTIONS)selected);
    }
}
