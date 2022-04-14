using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeAttackState : State
{
    private NavMeshAgent agent;

    private State chaseState;

    private bool isPlayerInAttackRange;

    [SerializeField] private GameObject projectile;

    private Transform player;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private Transform firePoint;

    private bool hasAttacked = false;
    private float attackCooldown = 2f;


    private void Start()
    {
        chaseState = GetComponent<RangeChaseState>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    public override State RunCurrentState()
    {
        isPlayerInAttackRange = Physics.CheckSphere(transform.position, Ranges.rangeAttack, playerLayer);

        if (isPlayerInAttackRange)
        {
            AttackPlayer();
            return this; 
        }
        else { return chaseState; }
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player.position);

        if (!hasAttacked)
        {
            Rigidbody rb = Instantiate(projectile, firePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);

            hasAttacked = true;
            Invoke(nameof(ResetAttack), attackCooldown);
        }
    }

    private void ResetAttack()
    {
        hasAttacked = false;
    }
}
