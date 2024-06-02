using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramline : MonoBehaviour
{
    public GameObject TramplineZone;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            Debug.Log("Lava Destroy");
            Destroy(TramplineZone);
            Destroy(gameObject);
        }
    }
}
