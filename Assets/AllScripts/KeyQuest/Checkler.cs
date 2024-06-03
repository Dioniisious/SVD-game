using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkler : MonoBehaviour
{
    public string cuurentText;
    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                //Debug.Log("Нажата клавиша: " + keyCode.ToString());
                cuurentText = keyCode.ToString();
            }
        }

    }
}
