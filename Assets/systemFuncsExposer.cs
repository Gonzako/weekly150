using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class systemFuncsExposer : MonoBehaviour
{
    public bool isGamePaused;

    public void pauseGame()
    {
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
    }
}
