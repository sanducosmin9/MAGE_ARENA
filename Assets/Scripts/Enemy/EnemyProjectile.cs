using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();

            health.TakeDamage(25);

            CreateImpact(collision.contacts[0].point);
        }

        CreateImpact(collision.contacts[0].point);
    }
}
