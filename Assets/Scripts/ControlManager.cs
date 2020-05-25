using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class ControlManager : MonoBehaviour
{

    [SerializeField] private BoolReference _canMove;
    [SerializeField] private BoolReference _cursorEnabled;

    playerMovement playerMovement;

    private void Start()
    {
        _canMove.Value = true;
        _cursorEnabled.Value = false;
    }
    // Update is called once per frame
    void Update()
    {
        playerMovement = GetComponent<playerMovement>();
        MovementCheck();
        CursorCheck();
    }

    private void MovementCheck()
    {
        if (!_canMove.Value)
        {
            playerMovement.enabled = false;
        }else
            playerMovement.enabled = true;
    }

    private void CursorCheck()
    {
        if (!_cursorEnabled.Value)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }else
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
    }
}
