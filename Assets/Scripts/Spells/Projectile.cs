using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject impactVFX;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(30);
            CreateImpact(collision.contacts[0].point);
        }

        bool canDestroy = !(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Spell"));

        if (canDestroy) { CreateImpact(collision.contacts[0].point); }
    }

    private void Start()
    {
        Destroy(gameObject, 4);
    }

    protected void CreateImpact(Vector3 point)
    {
        var impact = Instantiate(impactVFX, point, Quaternion.identity) as GameObject;

        Destroy(impact, 2);

        Destroy(gameObject);
    }
}
