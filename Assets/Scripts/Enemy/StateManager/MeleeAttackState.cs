using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MeleeAttackState : BaseState
{
    protected NavMeshAgent agent;
    public Animator animator;

    private Transform player;
    [SerializeField] private LayerMask playerLayer;

    protected bool canSwitchState;
    protected float attackCooldown;

    protected abstract IEnumerator Attack();
    protected abstract void SetCooldown();

    public override void EnterState(EnemyStateManager manager)
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        SetCooldown();

        canSwitchState = false;
        
        StartCoroutine(Attack());
    }
    public override void UpdateState(EnemyStateManager manager)
    {
        transform.LookAt(player.position);
        agent.SetDestination(transform.position);
        if (canSwitchState)
            manager.SwitchState(manager.chaseState);
    }
}