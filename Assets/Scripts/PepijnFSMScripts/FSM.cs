using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IState
{
    void Enter();
    void Execute();
    void Exit();
}

public class StateMachine
{
    IState currentState;
    //public static Dictionary<EventEnum, System.Action> stateMachineDic = new Dictionary<EventEnum, System.Action>();
    public void RunState()
    {
        //Een referentie naar deze funtie zetten in de gamemanager zodat het werkt.
        if (currentState != null) currentState.Execute();
    }

    public void ChangeState(IState _newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = _newState;
        currentState.Enter();
    }
}

public class FirstState : IState
{
    StateMachine MyFSM = new StateMachine();
    public void Enter()
    {
        Debug.Log("entering state");
    }

    public void Execute()
    {
        Debug.Log("execute state");
        MyFSM.ChangeState(new SecondState());
    }

    public void Exit()
    {
        Debug.Log("exiting state");
    }
}

public class SecondState : IState
{
    public void Enter()
    {
        Debug.Log("entering state");
    }

    public void Execute()
    {
        Debug.Log("execute state");
    }

    public void Exit()
    {
        Debug.Log("exiting state");
    }
}