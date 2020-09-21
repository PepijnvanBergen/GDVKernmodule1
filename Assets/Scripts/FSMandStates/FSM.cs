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

public static class StateMachine
{
    static IState _currentState;
    //public static Dictionary<EventEnum, System.Action> stateMachineDic = new Dictionary<EventEnum, System.Action>();
    public static void RunState()
    {
        //Een referentie naar deze funtie zetten in de gamemanager zodat het werkt.
        if (_currentState != null)
        {
            _currentState.Execute();
        }
    }

    public static void ChangeState(IState _newState)
    {
        Debug.Log("change state");
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = _newState;
        _currentState.Enter();
    }
}