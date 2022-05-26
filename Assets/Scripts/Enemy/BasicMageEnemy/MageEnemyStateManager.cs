using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEnemyStateManager : EnemyStateManager
{
    private void Start()
    {
        patrolState = GetComponent<MageEnemyPatrolState>();
        chaseState = GetComponent<MageEnemyChaseState>();
        attackState = GetComponent<MageEnemyAttackState>();

        currentState = patrolState;
        currentState.EnterState(this);
    }
}
