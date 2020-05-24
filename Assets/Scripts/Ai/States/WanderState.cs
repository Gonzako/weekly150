using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : BaseAIState
{
    public WanderState(AIManager ai) : base(ai)
    {
        _ai = ai;
        _scanner = _ai.GetComponent<AIScanner>();
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
        
        Debug.Log(_scanner._visibleTargets.Count);
        if(_scanner._visibleTargets.Count >= 1)
        {
            return typeof(FleeState);
        }
        return null;
    }
}
