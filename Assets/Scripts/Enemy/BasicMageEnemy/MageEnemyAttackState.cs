using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEnemyAttackState : RangeAttackState
{
    [SerializeField] private GameObject projectile;
    protected override void SetCooldown()
    {
        attackRange = EnemyRanges.rangeAttack;
        attackCooldown = 2f;
    }

    protected override IEnumerator Attack()
    {
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void LaunchProjectile()
    {
        Rigidbody rb = Instantiate(projectile, firePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 40f, ForceMode.Impulse);
    }
}
