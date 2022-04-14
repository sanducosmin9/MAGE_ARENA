using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeChaseState : State
{
    private NavMeshAgent agent;

    private State patrolState;
    private State attackState;

    private bool isPlayerInSight;
    private bool isPlayerInAttackRange;

    private Transform player;
    [SerializeField] private LayerMask playerLayer;
    private void Start()
    {
        player = GameObject.Find("Player").transform;
        patrolState = GetComponent<PatrolState>();
        attackState = GetComponent<RangeAttackState>();
        agent = GetComponent<NavMeshAgent>();
    }

    public override State RunCurrentState()
    {
        isPlayerInSight = Physics.CheckSphere(transform.position, Ranges.sight, playerLayer);
        isPlayerInAttackRange = Physics.CheckSphere(transform.position, Ranges.rangeAttack, playerLayer);

        if (!isPlayerInSight)
        {
            return patrolState;
        }

        if (isPlayerInAttackRange)
        {
            return attackState;
        }

        ChasePlayer();
        return this;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
}
