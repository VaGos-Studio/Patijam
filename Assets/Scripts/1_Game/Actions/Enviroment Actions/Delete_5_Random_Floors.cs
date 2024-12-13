using System.Collections.Generic;
using System;

public static class Delete_5_Random_Floors
{
    public static void Execute()
    {
        Random random = new Random();
        List<int> config = new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        // Lista de índices disponibles
        List<int> availableIndices = new List<int>();
        for (int i = 1; i < config.Count-1; i++)
        {
            availableIndices.Add(i);
        }

        for (int i = 0; i < 5; i++)
        {
            // Obtener un índice aleatorio de los disponibles
            int randomIndex = random.Next(availableIndices.Count);
            int index = availableIndices[randomIndex];

            // Actualizar config y eliminar el índice de la lista de disponibles
            config[index] = 0;
            availableIndices.RemoveAt(randomIndex);
        }

        EnviromentController.Instance.SetBlockConfig(config);
    }
}

