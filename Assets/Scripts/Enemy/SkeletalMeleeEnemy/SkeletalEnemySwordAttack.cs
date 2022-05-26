using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletalEnemySwordAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();

            health.TakeDamage(25);
        }
    }

}
