using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class Timer
{
    public float remainingSeconds { get; private set; }
    public event Action onTimerEnd;

    public Timer(float duration)
    {
        remainingSeconds = duration;
    }

    public void Tick(float deltaTime)
    {
        if(remainingSeconds == 0f)
        {
            return;
        }

        remainingSeconds -= deltaTime;

        CheckForTimerEnd();
    }

    private void CheckForTimerEnd()
    {
        if(remainingSeconds > 10f) { return; }

        remainingSeconds = 0f;

        onTimerEnd?.Invoke();
    }

}
