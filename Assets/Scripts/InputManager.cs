using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Vector2 moveInput { get; private set; }

    private bool _shootInput;
    private bool _runInput;

    // Update is called once per frame
    public void InputUpdate()
    {
        _shootInput = Input.GetKeyDown(KeyCode.Space);
        _runInput = Input.GetKeyDown(KeyCode.LeftControl);
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            EventManager.RaiseEvent(EventEnum.ON_MOVE);
        }
        if (_shootInput)
        {
            EventManager.RaiseEvent(EventEnum.ON_SHOOT);
        }
        if (_runInput)
        {
            EventManager.RaiseEvent(EventEnum.ON_RUN);
        }
        //moveInput = new Vector2(Input.GetAxis("Horizontal"), 0f);

    }
}
