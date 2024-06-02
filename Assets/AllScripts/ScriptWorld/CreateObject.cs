using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject[] gameObjectPossibly;
    public GameObject swordInMenu, sheildInMenu, hammerInMenu, keyInMenu, bridgeInMenu, tramplineInMenu, heartInMenu;
    public GameObject swordReal, sheildReal, hammerReal, keyReal, bridgeReal, tramplineReal, heartReal;

    private void Awake()
    {
        swordInMenu = GameObject.FindGameObjectWithTag("SwordMenu");
        sheildInMenu = GameObject.FindGameObjectWithTag("SheildMenu");
        hammerInMenu = GameObject.FindGameObjectWithTag("HammerMenu");
        keyInMenu = GameObject.FindGameObjectWithTag("KeyMenu");
        bridgeInMenu = GameObject.FindGameObjectWithTag("BridgeMenu");
        tramplineInMenu = GameObject.FindGameObjectWithTag("TramplineMenu");
        heartInMenu = GameObject.FindGameObjectWithTag("HeartMenu");
    }



    public void CreateObjectWhen(GameObject gameObject, Transform SpawnPoint)
    {
        Instantiate(gameObject, SpawnPoint);
    }
}
