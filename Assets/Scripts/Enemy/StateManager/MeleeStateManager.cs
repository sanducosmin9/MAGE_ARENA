using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeStateManager : StateManager
{
    private void Start()
    {
        currentState = GetComponent<MeleeChaseState>();
    }
}
