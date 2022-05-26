using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemBossChaseState : StateMachineBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    private float attackRange;

    public LayerMask playerLayer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        attackRange = EnemyRanges.bossMeleeAttack;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);

        bool isPlayerInAttackRange = Physics.CheckSphere(agent.transform.position, attackRange, playerLayer);
        if (isPlayerInAttackRange)
            animator.SetTrigger("Attack");
    }

/*    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }*/
}
