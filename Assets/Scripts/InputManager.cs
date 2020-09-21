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
            Debug.Log("pieuw");
        }

        else if (Input.GetKey(KeyCode.A))
        {
            EventManager.RaiseEvent(EventEnum.ON_MOVEL);
            Debug.Log("walkL");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            EventManager.RaiseEvent(EventEnum.ON_MOVER);
            Debug.Log("walkR");
        }

        else if (Input.GetKey(KeyCode.Q))
        {
            EventManager.RaiseEvent(EventEnum.ON_RUNL);
            Debug.Log("RunL");
        }
        else if (Input.GetKey(KeyCode.E))
        {
            EventManager.RaiseEvent(EventEnum.ON_RUNR);
            Debug.Log("RunR");
        }
        else
        {
            EventManager.RaiseEvent(EventEnum.ON_IDLE);
        }
    }
}
