using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class systemFuncsExposer : MonoBehaviour
{
    [SerializeField] public BoolReference isGamePaused;
    [SerializeField] public GameEvent onPause;
 
    public void PauseGame()
    {
        Time.timeScale = 0;
        isGamePaused.Value = true;
        onPause.Raise();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isGamePaused.Value = false;
        onPause.Raise();
    }
}
