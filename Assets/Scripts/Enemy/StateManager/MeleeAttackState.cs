using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeAttackState : State
{
    private NavMeshAgent agent;
    private Animator animator;

    private State chaseState;
    private bool isPlayerInAttackRange;

    private Transform player;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private Transform arm;

    private bool hasAttacked = false;
    private float attackCooldown = 0.5f;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        chaseState = GetComponent<MeleeChaseState>();
        agent = GetComponent<NavMeshAgent>();
        animator = arm.GetComponent<Animator>();
    }
    public override State RunCurrentState()
    {
        isPlayerInAttackRange = Physics.CheckSphere(transform.position, Ranges.meleeAttack, playerLayer);

        if (!isPlayerInAttackRange) { return chaseState; }

        AttackPlayer();
        return this;
    }

    private void AttackPlayer()
    {
        if (!hasAttacked)
        {
            transform.LookAt(player.position);

            animator.SetBool("canAttack", true);
            hasAttacked = true;
            Invoke(nameof(ResetAttack), attackCooldown);
        }
    }

    private void ResetAttack()
    {
        animator.SetBool("canAttack", false);
        hasAttacked = false;
    }
}
