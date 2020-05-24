using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class GameManager : MonoBehaviour
{

    [Header("Events")]
    [SerializeField] private GameEvent onLevelFailure;
    [SerializeField] private GameEvent onLevelComplete;
    [SerializeField] private GameObjectGameEventListener CivilianKillListener;

    [Header("Variables")]
    [SerializeField] private FloatReference _timer;
    [SerializeField] private FloatReference _eatableCivs;

    [Header("Settings")]
    [SerializeField] private float _levelCompletionTime;

 
    private void Start()
    {
        _eatableCivs.Value = FindObjectsOfType<AIManager>().Length;
        _timer.Value = _levelCompletionTime;
        StartCoroutine(GameCycle());
    }

    private void Update()
    {
        _timer.Value -= Time.smoothDeltaTime;
    }

    private IEnumerator GameCycle()
    {
        while (true){
            yield return new WaitForSeconds(0.5F);
            if (_timer.Value == 0)
            {
                onLevelFailure.Raise();
                StopAllCoroutines();
            }
            if (_eatableCivs.Value == 0)
            {
                onLevelComplete.Raise();
                StopAllCoroutines();
            }
        }
    }

    public void RemoveCivilianCount(GameObject ob)
    {
        Debug.Log(ob.name);
        _eatableCivs.Value -= 1;
    }
}
