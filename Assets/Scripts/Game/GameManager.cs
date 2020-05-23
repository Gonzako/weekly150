using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class GameManager : MonoBehaviour
{

    [Header("Events")]
    [SerializeField] private GameEvent onLevelFailure;
    [SerializeField] private GameEvent onLevelComplete;
    [SerializeField] private GameEventListener CivilianKillListener;

    [Header("Variables")]
    [SerializeField] private FloatReference _timer;
    [SerializeField] private FloatReference _eatableCivs;

    [Header("Settings")]
    [SerializeField] private float _levelCompletionTime;

 

    private void Start()
    {
        _eatableCivs.Value = FindObjectsOfType<AIManager>().Length;
        _timer.Value = _levelCompletionTime;
    }

    private void Update()
    {
        _timer.Value -= Time.smoothDeltaTime;

        if(_timer.Value == 0)
        {
            onLevelFailure.Raise();
        }
        if(_eatableCivs.Value == 0)
        {
            onLevelComplete.Raise();
        }
    }

    public void RemoveCivilianCount()
    {
        _eatableCivs.Value -= 1;
    }


}
