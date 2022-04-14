using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private HealthSystem health;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image deathScreen;

    void Start()
    {
        health = new HealthSystem(100);
        healthSlider.maxValue = 100;
        healthSlider.minValue = 0;
    }

    private void Update()
    {
        if (health.isZero)
        {
            var movement = GetComponent<PlayerMovement>();
            var attack = GetComponent<FireProjectileSpell>();

            movement.enabled = false;
            attack.enabled = false;

            deathScreen.gameObject.SetActive(true);
        }


        healthSlider.value = health.GetHealth();
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
