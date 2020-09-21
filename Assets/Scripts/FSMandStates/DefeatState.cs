using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatState : IState
{
    StateMachine MyFSM = new StateMachine();
    public void Enter()
    {
        Debug.Log("entering state");
    }

    public void Execute()
    {
        Debug.Log("execute state");
        MyFSM.ChangeState(new MoveState());
    }

    public void Exit()
    {
        Debug.Log("exiting state");
    }
}
