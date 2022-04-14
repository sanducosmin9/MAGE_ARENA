using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(10);

            var enemyAgent = collision.gameObject.GetComponent<NavMeshAgent>();
            enemyAgent.isStopped = true;
            Debug.Log("hei");
        }
    }

    private void Start()
    {
        Destroy(gameObject, 4);
    }
}
