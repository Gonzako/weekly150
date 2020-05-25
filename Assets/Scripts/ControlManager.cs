using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class ControlManager : MonoBehaviour
{

    [SerializeField] private BoolReference _canMove;
    [SerializeField] private BoolReference _cursorEnabled;

    private void Start()
    {
        _canMove.Value = true;
        _cursorEnabled.Value = false;
    }
    // Update is called once per frame
    void Update()
    {
        MovementCheck();
        CursorCheck();
    }

    private void MovementCheck()
    {
        if (!_canMove.Value)
        {
            GetComponent<playerMovement>().enabled = false;
        }else
            GetComponent<playerMovement>().enabled = true;
    }

    private void CursorCheck()
    {
        if (!_cursorEnabled.Value)
        {
            Cursor.visible = false;
        }else
            Cursor.visible = true;
    }
}
