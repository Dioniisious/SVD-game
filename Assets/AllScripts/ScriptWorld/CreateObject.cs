using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject[] gameObjectPossibly;
    public GameObject swordReal, sheildReal, hammerReal, keyReal, bridgeReal, tramplineReal, heartReal;

    public void CreateObjectWhen(GameObject gameObject, Transform SpawnPoint)
    {
        Instantiate(gameObject, SpawnPoint);
    }
}
