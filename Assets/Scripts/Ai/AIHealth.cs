using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class AIHealth : MonoBehaviour, IEatable
{

    [SerializeField] private GameObjectGameEvent onNPCKilled;
    [SerializeField] private GameObjectEvent onKilled;

    private bool killed = false;

    public void Kill()
    {
        if (!killed)
        {
            killed = true;
            onKilled?.Invoke(gameObject);
            onNPCKilled.Raise(gameObject);
        }
    }
}
