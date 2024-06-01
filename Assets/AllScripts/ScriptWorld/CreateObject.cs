using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject[] gameObjectPossibly;

    public void CreateObjectWhen(int numberPossibly, Transform position)
    {
        Instantiate(gameObjectPossibly[numberPossibly], position);
    }
}
