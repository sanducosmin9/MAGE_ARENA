using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornsAttack : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();

            health.TakeDamage(enemyHealth.attackDamage);
        }
    }
}
