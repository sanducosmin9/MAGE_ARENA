using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private Animator animator;
    private HealthSystem health;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject impactVFX;
    private bool hasRaged = false;
    public float maxHealth = 100;
    public float attackDamage = 25;

    void Start()
    {
        animator = GetComponent<Animator>();
        health = new HealthSystem(maxHealth);
        healthSlider.maxValue = maxHealth;
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

        if (!hasRaged && health.isBelowHalf && animator != null)
        {
            hasRaged = true;
            animator.SetTrigger("Rage");
            animator.SetBool("HasRaged", true);
        }
    }

    public void Heal(float amount)
    {
        health.Heal(amount);
    }
}
