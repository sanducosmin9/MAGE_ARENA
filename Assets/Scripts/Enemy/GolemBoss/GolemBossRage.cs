using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemBossRage : StateMachineBehaviour
{
    private NavMeshAgent agent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        var health = animator.GetComponent<EnemyHealth>();
        health.Heal(health.maxHealth / 4);
        health.attackDamage += 10;
        agent.speed += 2;
    }
}
