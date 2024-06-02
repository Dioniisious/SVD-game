using System.Collections.Generic;
using UnityEngine;

public partial class PlayerKeyChecker : MonoBehaviour
{
    // ��������� 5 ��������� ��������:
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

        Debug.Log("������������ ���������� ������ ��� ����������� �����������");
        return outputChars;
    }
}