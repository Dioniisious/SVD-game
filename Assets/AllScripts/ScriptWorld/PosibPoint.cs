using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosibPoint : MonoBehaviour
{
    public GameObject cEC;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            cEC.SetActive(true);
        }
    }
    
}
