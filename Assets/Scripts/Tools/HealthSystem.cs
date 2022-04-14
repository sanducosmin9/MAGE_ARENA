using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    private float health;
    private float maxHealth;
    public bool isZero = false;

    public HealthSystem(float maxHealth)
    {
        this.maxHealth = maxHealth;
        this.health = maxHealth;
    }

    public float GetHealth()
    {
        return health;
    }

    public void Damage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            health = 0;
            isZero = true;
        }
    }

    public void Heal(float amount)
    {
        health += amount;

        if(health > maxHealth) 
            health = maxHealth;
        
    }
}
