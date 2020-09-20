using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Vector2 moveInput { get; private set; }

    private bool _shootInput;
    private bool _runInput;

    // Update is called once per frame
/*
Wat we moeten doen

Input manager, die moet input geven, die een event aanzet; MoveL, MoveR

PlayerMovement, luisteren naar de event, en dan links of rechts gaan.

Probleem, ik wil ook rennen dus ik moet of 4 events en 4 states en 4 functies gaan maken voor de movement.
Wat kapot omslachtig is.

Of ik moet een andere mannier vinden.




*/
    public void InputUpdate()
    {
        _shootInput = Input.GetKeyDown(KeyCode.Space);
        _runInput = Input.GetKeyDown(KeyCode.LeftControl);
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            EventManager.RaiseEvent(EventEnum.ON_MOVEL);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            EventManager.RaiseEvent(EventEnum.ON_MOVER);
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
