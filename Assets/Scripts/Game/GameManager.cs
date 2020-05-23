using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public delegate void GameEvents();
    public GameEvents onLevelComplete;
    public GameEvents onLevelFail;

    [SerializeField] private float _timer;

    private void Update()
    {
        
    }


}
