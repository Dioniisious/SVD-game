using System.Collections.Generic;
using UnityEngine;

public partial class PlayerKeyChecker : MonoBehaviour
{
    private List<KeyCode> _pressedKeys = new();
    private int _equalityCounter = 0;
    private List<string> _correctAnswers = GenerateRandomNums();

    void Update()
    {
        // ���������, ����� ������� ���� ������:
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                Debug.Log("������ �������: " + keyCode.ToString());
                _pressedKeys.Add(keyCode);
            }
        }

        // ���������, ����� ������� ���� ��������:
        List<KeyCode> releasedKeys = new List<KeyCode>();
        foreach (KeyCode keyCode in _pressedKeys)
        {
            if (!Input.GetKey(keyCode))
            {
                Debug.Log("�������� �������: " + keyCode.ToString());
                releasedKeys.Add(keyCode);
            }
        }

        // ������� ���������� ������� �� ������ �������:
        foreach (KeyCode releasedKey in releasedKeys)
        {
            _pressedKeys.Remove(releasedKey);
        }

        // ��� ������� ���� 5 - �������� ������������:
        if (_pressedKeys.Count == 5)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = i; i < 5; j++)
                {
                    if (_pressedKeys[i].ToString() != _correctAnswers[j])
                    {
                        _equalityCounter ++;
                        break;
                    }
                }
            }

            if (_equalityCounter == 5)
            {
                Debug.Log("���������� ������� �� �������, ����� �������� ����");
                // �������� ����
            }
        }
    }
}
