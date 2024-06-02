using System.Collections.Generic;
using UnityEngine;

public partial class PlayerKeyChecker : MonoBehaviour
{
    // Генератор 5 рандомных символов:
    public static List<string> GenerateRandomNums()
    {
        const string charsForRandom = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        System.Random generator = new();
        List<string> outputChars = new();
        string current;

        for (int i = 0; i < 5; i++)
        {
            current = charsForRandom[generator.Next(0, 35)].ToString();
            outputChars.Add(current);
        }

        Debug.Log("Сформирована комбинация клавиш для преодоления препятствия");
        return outputChars;
    }
}