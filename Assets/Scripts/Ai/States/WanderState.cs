using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : BaseAIState
{
    public WanderState(AIManager ai) : base(ai)
    {
        _ai = ai;
        _scanner = ai.GetComponent<AIScanner>();
    }

    public override AIManager _ai { get; set; }

    private AIScanner _scanner;

    public override void OnStateEnter()
    {
        _ai.StartCoroutine(_ai.Wander());
    }

    public override void OnStateExit()
    {
        _ai.StopAllCoroutines();
    }

    public override Type Tick()
    {
     
        if(_scanner._visibleTargets.Count > 0)
        {
            return typeof(FleeState);
        }
        return null;
    }
}
