using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    protected State currentState;

    private void Start()
    {
        currentState = GetComponent<PatrolState>();
    }
    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();

        if(nextState != null) { SwitchToNextState(nextState); }
    }

    private void SwitchToNextState(State nextState)
    {
        currentState = nextState;
    }
}
