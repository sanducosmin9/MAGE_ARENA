using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeChaseState : State
{
    private NavMeshAgent agent;

    private State attackState;
    private bool isPlayerInAttackRange;

    private Transform player;
    [SerializeField] private LayerMask playerLayer;


    private void Start()
    {
        player = GameObject.Find("Player").transform;
        attackState = GetComponent<MeleeAttackState>();
        agent = GetComponent<NavMeshAgent>();
    }
    public override State RunCurrentState()
    {
        isPlayerInAttackRange = Physics.CheckSphere(transform.position, Ranges.meleeAttack, playerLayer);

        if (isPlayerInAttackRange) { return attackState; }

        ChasePlayer();
        return this;
    }

    private void ChasePlayer()
    {
        transform.LookAt(player.position);
        agent.SetDestination(player.position);
    }
}
