using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlusHealth")
        {
            HealthPlayer health = gameObject.GetComponent<HealthPlayer>();
            health.SetHealth();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "PlusPaper")
        {
            Paper paper = gameObject.GetComponent<Paper>();
            paper.SetPaper();
            Destroy(collision.gameObject);
        }
    }
}
