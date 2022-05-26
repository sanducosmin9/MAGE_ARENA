using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletalEnemyStateManager : EnemyStateManager
{
    void Start()
    {
        patrolState = GetComponent<PatrolState>();
        chaseState = GetComponent<ChaseState>();
        attackState = GetComponent<SkeletalEnemyAttackState>();

        currentState = patrolState;
        currentState.EnterState(this);
    }

}
