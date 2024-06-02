using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosibPoint : MonoBehaviour
{
    public GameObject posPointEnable;
    public Transform SpawnPoint;
    public bool activeBuild = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            posPointEnable.SetActive(true);
            activeBuild = true;
}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(posPointEnable);
            activeBuild = false;
        }
    }

}
