using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class GameManager : MonoBehaviour
{

    [Header("Events")]
    [SerializeField] private GameEvent onLevelFailure;
    [SerializeField] private GameEvent onLevelComplete;
    [SerializeField] private GameEvent onGameComplete;

    [Header("Variables")]
    [SerializeField] private FloatReference _timer;
    [SerializeField] private FloatReference _eatableCivs;
    [SerializeField] private BoolReference _canMove;
    [SerializeField] private BoolReference _cursorEnabled;

    [Header("Settings")]
    [SerializeField] private float _levelCompletionTime;


    private void Awake()
    {
        _timer.Value = _levelCompletionTime;
    }

    private void Start()
    {
        _eatableCivs.Value = FindObjectsOfType<AIManager>().Length;
    }

    private void Update()
    {
        _timer.Value -= Time.smoothDeltaTime;

        if(_timer.Value <= 0F)
        {
            onLevelFailure.Raise();
            _canMove.Value = false;
            _cursorEnabled.Value = true;
            if (SceneSwitchManager._instance.isLastLevel())
            {
                onGameComplete.Raise();
            }
        }
        if(_eatableCivs.Value == 0F)
        {
            onLevelComplete.Raise();
            _canMove.Value = false;
            _cursorEnabled.Value = true;
        }
    }

    public void RemoveCivilianCount(GameObject ob)
    {
        Debug.Log("GAME: " + ob);
        _eatableCivs.Value -= 1;
    }


}
