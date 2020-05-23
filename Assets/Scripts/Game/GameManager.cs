using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class GameManager : MonoBehaviour
{

    public delegate void GameEvents();
    public GameEvents onLevelComplete;
    public GameEvents onLevelFail;

    [SerializeField] private FloatReference _timer;
    [SerializeField] private FloatReference _eatableCivs;


    private void Start()
    {
        _eatableCivs.Value = FindObjectsOfType<AIManager>().Length;
    }

    private void Update()
    {
        _timer.Value -= Time.smoothDeltaTime;
    }


}
