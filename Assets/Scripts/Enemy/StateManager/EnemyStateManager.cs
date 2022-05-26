using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    protected BaseState currentState;

    public BaseState patrolState;
    public BaseState chaseState;
    public BaseState attackState;

    void Update()
    {
        currentState.UpdateState(this);   
    }

    public void SwitchState(BaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
}
