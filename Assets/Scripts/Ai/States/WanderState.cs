using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : BaseAIState
{
    public WanderState(AIManager ai) : base(ai)
    {
        _ai = ai;
    }

    public override AIManager _ai { get; set; }

    public override void OnStateEnter()
    {
        _ai.StartCoroutine(_ai.Wander());
    }

    public override void OnStateExit()
    {
        _ai.StopCoroutine(_ai.Wander());
    }

    public override Type Tick()
    {
        Transform[] targets = _ai.GetComponent<AIScanner>()._visibleTargets.ToArray();
        if(targets.Length > 0)
        {
            return typeof(FleeState);
        }
        return null;
    }
}
