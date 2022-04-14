using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private HealthSystem health;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject impactVFX;

    void Start()
    {
        health = new HealthSystem(90);
        healthSlider.maxValue = 90;
        healthSlider.minValue = 0;
    }

    private void Update()
    {
        if (health.isZero)
        {
            CreateDeathEffect();
        }

        healthSlider.value = health.GetHealth();
    }

    private void CreateDeathEffect()
    {
        var impact = Instantiate(impactVFX, transform.position, Quaternion.identity) as GameObject;

        Destroy(impact, 2);

        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        health.Damage(amount);
    }

    public void Heal(float amount)
    {
        health.Heal(amount);
    }
}
