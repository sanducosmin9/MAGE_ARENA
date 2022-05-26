using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletalEnemyChaseState : ChaseState
{
    protected override void ChasePlayer()
    {
        animator.SetBool("Move", true);
        agent.SetDestination(player.position);
    }

    protected override void SetRanges()
    {
        sightRange = EnemyRanges.meleeSight;
        attackRange = EnemyRanges.meleeAttack;
    }
}
