using UnityEngine;

public class MoveState : IState
{
    //enemy myenemey = new enemy();
    StateMachine MyFSM = new StateMachine();
    PlayerStateMachine MyPFSM = new PlayerStateMachine();
    public void Enter()
    {
        MyPFSM.ChangePlayerState(new PlayerShootState());
        Debug.Log("entering state");
    }

    public void Execute()
    {
        //myenemy.move();
        Debug.Log("execute state");
        MyPFSM.RunPlayerState();
        //MyFSM.ChangeState(new DefeatState());
        //MyFSM.ChangeState(new WinState());
    }

    public void Exit()
    {
        Debug.Log("exiting state");
    }
}