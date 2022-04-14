using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using Random = UnityEngine.Random;

public class PatrolState : State
{
    private NavMeshAgent agent;

    private bool isPlayerInSight;
    private State chaseState;

    private Vector3 walkPoint;
    private bool isWalkPointSet = false;

    private Vector3[] patrolPoints;
    private int currentPointIndex = 0;

    private Transform player;
    [SerializeField] private LayerMask groundLayer, playerLayer;

    private void Start()
    {
        chaseState = GetComponent<RangeChaseState>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        InitializePatrolPoints();
    }

    private void InitializePatrolPoints()
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

    public override State RunCurrentState()
    {
        isPlayerInSight = Physics.CheckSphere(transform.position, Ranges.sight, playerLayer);
        if (isPlayerInSight) 
        { 
            return chaseState; 
        }
        else 
        { 
            Patrol(); 
            return this; 
        }
        
    }

    private void Patrol()
    {
        if(!isWalkPointSet) { GoToNextPoint(); }
        if(isWalkPointSet) { agent.SetDestination(walkPoint); }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.sqrMagnitude < 1f)
            isWalkPointSet = false; 
    }

    private void GoToNextPoint()
    { 
        walkPoint = patrolPoints[currentPointIndex];
        
        if (++currentPointIndex >= patrolPoints.Length)
            currentPointIndex = 0;

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayer))
            isWalkPointSet = true;
    }
}
