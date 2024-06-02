using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject[] gameObjectPossibly;
    public GameObject swordInMenu, sheildInMenu, hammerInMenu, keyInMenu, bridgeInMenu, tramplineInMenu, heartInMenu;

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

    public void CreateObjectWhen(int numberPossibly, Transform position)
    {
        Instantiate(gameObjectPossibly[numberPossibly], position);
    }
}
