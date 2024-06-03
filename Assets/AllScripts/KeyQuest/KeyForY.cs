using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyForY : MonoBehaviour
{

    string generateText = null;
    public string GenerateRandomNums()
    {
        const string charsForRandom = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        generateText = null;

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
            generateText += str;
            Debug.Log(str);
        }
        return generateText;
    }
}
