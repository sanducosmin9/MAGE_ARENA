using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEnemyChaseState : ChaseState
{
    protected override void SetRanges()
    {
        sightRange = EnemyRanges.sight;
        attackRange = EnemyRanges.rangeAttack;
        animator.SetBool("Chase", true);
    }

    protected override void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }


}
