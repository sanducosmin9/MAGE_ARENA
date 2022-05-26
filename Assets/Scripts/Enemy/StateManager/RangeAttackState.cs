using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class RangeAttackState : BaseState
{
    protected NavMeshAgent agent;
    public Animator animator;

    protected Transform player;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] protected Transform firePoint;

    protected float attackCooldown;
    protected bool canAttack;
    protected float attackRange;

    protected abstract IEnumerator Attack();
    protected abstract void SetCooldown();

    public override void EnterState(EnemyStateManager manager)
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        SetCooldown();

        canAttack = true;
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        if (canAttack)
        {
            canAttack = false;
            StartCoroutine(Attack());
        }

        Vector3 lookDirection = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookDirection);
        agent.SetDestination(transform.position);

        bool isPlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
        if (!isPlayerInAttackRange)
        {
            animator.SetBool("Attack", false);
            manager.SwitchState(manager.chaseState);
        }
    }

}
