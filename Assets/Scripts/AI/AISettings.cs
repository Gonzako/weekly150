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
    [Tooltip("How long should AI wait before wandering to next random spot?")]
    [SerializeField] public float _wanderMovementCycle = 3F;
    [Tooltip("How far can AI decide to wander of after every cycle?")]
    [SerializeField] public float _wanderRadius = 3F;


  

}
