using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthValue;

    public void TakeHit(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;

        if (health >= maxHealth)
            health = maxHealth;
    }
}
