using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEnemyPatrolState : PatrolState
{
    protected override void InitializePatrolPoints()
    {
        float agentX = transform.position.x;
        float agentY = transform.position.y;
        float agentZ = transform.position.z;

        patrolPoints = new Vector3[4];
        patrolPoints[0] = new Vector3(agentX + 10f, agentY, agentZ + 10);
        patrolPoints[1] = new Vector3(agentX + 10f, agentY, agentZ - 10);
        patrolPoints[2] = new Vector3(agentX - 10f, agentY, agentZ - 10);
        patrolPoints[3] = new Vector3(agentX - 10f, agentY, agentZ + 10);
    }

    protected override void SetSightRange()
    {
        animator.SetBool("Chase", false);
        sightRange = EnemyRanges.sight;
    }
}
