using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ChaseState : BaseState
{
    protected NavMeshAgent agent;
    protected Transform player;
    public Animator animator;

    protected float attackRange;
    protected float sightRange;

    [SerializeField] private LayerMask playerLayer;

    protected abstract void ChasePlayer();
    protected abstract void SetRanges();

    public override void EnterState(EnemyStateManager manager)
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        agent.speed = 8;
        SetRanges();
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        bool isPlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        if (!isPlayerInSightRange)
            manager.SwitchState(manager.patrolState);

        bool isPlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
        if (isPlayerInAttackRange)
            manager.SwitchState(manager.attackState);
        
        ChasePlayer();
    }
}
