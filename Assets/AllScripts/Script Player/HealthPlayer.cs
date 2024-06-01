using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public float health;
    private float maxHealth = 3;
    public Image[] healths = new Image[3];

    private void Start()
    {
        HealthScore(health);
    }

    public void TakeHit()
    {
        health -= 1;
        HealthScore(health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }


    }

    public void SetHealth()
    {
        health += 1;
        HealthScore(health);

        if (health >= maxHealth)
            health = maxHealth;
    }

    private void HealthScore(float health)
    {
        switch (health)
        {
            case 3:
                {
                    healths[0].enabled = true;
                    healths[1].enabled = true;
                    healths[2].enabled = true;
                    break;
                }
            case 2:
                {
                    healths[0].enabled = true;
                    healths[1].enabled = true;
                    healths[2].enabled = false;
                    break;
                }
            case 1:
                {
                    healths[0].enabled = true;
                    healths[1].enabled = false;
                    healths[2].enabled = false;
                    break;
                }
            case 0:
                {
                    healths[0].enabled = false;
                    healths[1].enabled = false;
                    healths[2].enabled = false;
                    break;
                }
        }
    }
}
