using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class PauseManager : MonoBehaviour
{
    [SerializeField] public BoolReference isGamePaused;

    [SerializeField] private BoolReference _canMove;
    [SerializeField] private BoolReference _cursorEnabled;

    [SerializeField] public GameEvent onResume;
    [SerializeField] public GameEvent onPause;

    [SerializeField] public KeyCode _pauseKey;

    private void Update()
    {
        if (Input.GetKeyDown(_pauseKey))
        {
            if (isGamePaused.Value)
                ResumeGame();
            else if (!isGamePaused.Value)
            {
                PauseGame();
            }
        }
            
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isGamePaused.Value = true;
        onPause.Raise();
        _canMove.Value = false;
        _cursorEnabled.Value = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isGamePaused.Value = false;
        onResume.Raise();
        _canMove.Value = true;
        _cursorEnabled.Value = false;
    }
}
