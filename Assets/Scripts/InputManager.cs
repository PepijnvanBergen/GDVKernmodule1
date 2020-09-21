using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public void InputUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.RaiseEvent(EventEnum.ON_SHOOT);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            EventManager.RaiseEvent(EventEnum.ON_MOVEL);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            EventManager.RaiseEvent(EventEnum.ON_MOVER);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            EventManager.RaiseEvent(EventEnum.ON_RUNL);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            EventManager.RaiseEvent(EventEnum.ON_RUNR);
        }
    }
}
