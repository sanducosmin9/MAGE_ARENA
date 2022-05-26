using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class PatrolState : BaseState
{
    private NavMeshAgent agent;
    public Animator animator;

    private Vector3 walkPoint;
    private bool isWalkPointSet = false;

    protected Vector3[] patrolPoints;
    private int currentPointIndex = 0;

    private Transform player;
    [SerializeField] private LayerMask groundLayer, playerLayer;

    protected float sightRange;
    protected abstract void InitializePatrolPoints();
    protected abstract void SetSightRange();
    public override void EnterState(EnemyStateManager manager)
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        agent.speed = 6;

        InitializePatrolPoints();
        SetSightRange();
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        bool isPlayerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);

        if (isPlayerInSight)
            manager.SwitchState(manager.chaseState);

        Patrol();
    }

    private void Patrol()
    {
        if (!isWalkPointSet) { GoToNextPoint(); }
        if (isWalkPointSet) { agent.SetDestination(walkPoint); }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.sqrMagnitude < 1f)
            isWalkPointSet = false;
    }

    private void GoToNextPoint()
    {
        walkPoint = patrolPoints[currentPointIndex];

        if (++currentPointIndex >= patrolPoints.Length)
            currentPointIndex = 0;

        isWalkPointSet = true;
    }
}
