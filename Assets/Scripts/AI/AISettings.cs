using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class AISettings 
{
    [Header("Movement")]
    [SerializeField] public float _movementSpeed = 3F;


    [Header("Wander")]
    [Tooltip("How long should AI wait before wandering to next random spot? (Seconds)")]
    [Range(0.0F, 60F)]
    [SerializeField] public float _wanderMovementCycle = 3F;
    [Tooltip("How far can AI decide to wander of after every cycle?")]
    [Range(0.0F, 200F)]
    [SerializeField] public float _wanderRadius = 3F;
    [Range(0.0F, 50F)]
    [SerializeField] public float _wanderSpeed;

    [Header("Flee")]
    [Range(0.0F, 50F)]
    [SerializeField] public float _fleeSpeed;
    [Tooltip("How long should AI wait before fleeing to next position? (Seconds)")]
    [Range(0.0F, 60F)]
    [SerializeField] public float _fleeMovementCycle = 3F;
    [Tooltip("How far can AI decide to wander of after every cycle?")]
    [Range(0.0F, 200F)]
    [SerializeField] public float _fleeRadius = 10F;


}
