using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IState
{
    void Enter();
    void Execute();
    void Exit();
}

//IPlayerState

public class StateMachine
{
    IState _currentState;
    //public static Dictionary<EventEnum, System.Action> stateMachineDic = new Dictionary<EventEnum, System.Action>();
    public void RunState()
    {
        //Een referentie naar deze funtie zetten in de gamemanager zodat het werkt.
        if (_currentState != null)
        {
            _currentState.Execute();
        }
    }

    public void ChangeState(IState _newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = _newState;
        _currentState.Enter();
    }
}