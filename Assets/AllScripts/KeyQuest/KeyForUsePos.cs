using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyForUsePos : MonoBehaviour
{
    // ��������� 5 ��������� ��������:
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

        Debug.Log("������������ ���������� ������ ��� ����������� ����������� (5 �������� ���������)");
        foreach (string str in outputChars)
        {

            Debug.Log(str);
        }
        return outputChars;
    }
}
