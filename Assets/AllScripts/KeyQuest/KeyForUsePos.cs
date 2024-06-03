using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyForUsePos : MonoBehaviour
{
    // Генератор 5 рандомных символов:
    public static List<string> GenerateRandomNums()
    {
        const string charsForRandom = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        System.Random generator = new();
        List<string> outputChars = new();
        string current;

        for (int i = 0; i < 5; i++)
        {
            current = charsForRandom[generator.Next(0, 25)].ToString();
            outputChars.Add(current);
        }

        Debug.Log("Сформирована комбинация клавиш для преодоления препятствия (5 символов построчно)");
        foreach (string str in outputChars)
        {

            Debug.Log(str);
        }
        return outputChars;
    }
}
