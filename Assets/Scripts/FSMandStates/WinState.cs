using UnityEngine;

public class WinState : IState
{
    StateMachine MyFSM = new StateMachine();
    public void Enter()
    {
        Debug.Log("entering state");
    }

    public void Execute()
    {
        Debug.Log("execute state");
        MyFSM.ChangeState(new SpawnState());
    }

    public void Exit()
    {
        Debug.Log("exiting state");
    }
}
