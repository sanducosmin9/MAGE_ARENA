using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletalEnemyAttackState : MeleeAttackState
{
    protected override IEnumerator Attack()
    {
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(attackCooldown);
        canSwitchState = true;
    }

    protected override void SetCooldown()
    {
        attackCooldown = 1f;
    }
}
