using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : BaseAIState
{
    public FleeState(AIManager ai) : base(ai)
    {
        _ai = ai;
    }

    public override AIManager _ai { get; set; }

    public override void OnStateEnter()
    {
        _ai.StartCoroutine(_ai.Flee());
    }

    public override void OnStateExit()
    {
        _ai.StopCoroutine(_ai.Flee());
    }

    public override Type Tick()
    {
        Transform[] targets = _ai.GetComponent<AIScanner>()._visibleTargets.ToArray();
        if (targets.Length == 0)
        {
            return typeof(WanderState);
        }
        return null;
    }
}
