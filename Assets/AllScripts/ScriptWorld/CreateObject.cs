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

    public GameObject swordInMenu = GameObject.FindGameObjectWithTag("SwordMenu");
    public GameObject sheildInMenu = GameObject.FindGameObjectWithTag("SheildMenu");
    public GameObject hammerInMenu = GameObject.FindGameObjectWithTag("HammerMenu");
    public GameObject keyInMenu = GameObject.FindGameObjectWithTag("KeyMenu");
    public GameObject bridgeInMenu = GameObject.FindGameObjectWithTag("BridgeMenu");
    public GameObject tramplineInMenu = GameObject.FindGameObjectWithTag("TramplineMenu");
    public GameObject heartInMenu = GameObject.FindGameObjectWithTag("HeartMenu");
}
