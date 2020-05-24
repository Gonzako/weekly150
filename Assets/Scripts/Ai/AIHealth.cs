using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class AIHealth : MonoBehaviour, IEatable
{

    [SerializeField] private GameObjectGameEvent onNPCKilled;
    [SerializeField] private GameObjectEvent onKilled;

    public void Kill()
    {
        onKilled?.Invoke(gameObject);
        onNPCKilled.Raise(gameObject);
    }
}
