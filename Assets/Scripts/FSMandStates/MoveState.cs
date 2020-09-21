using UnityEngine;

public class MoveState : IState
{
    //enemy myenemey = new enemy();
    StateMachine MyFSM = new StateMachine();
    //PlayerStateMachine MyPFSM = new PlayerStateMachine();
    //Bullet MyB;
    public void Enter()
    {
        //MyB = new Bullet();
        //MyPFSM.ChangePlayerState(new PlayerShootState());
        Debug.Log("entering state");
    }
    public void Execute()
    {
        //myenemy.move();
        Debug.Log("execute state");
        //MyPFSM.RunPlayerState();
        //MyB.BulletUpdate();

        //MyFSM.ChangeState(new DefeatState());
        //MyFSM.ChangeState(new WinState());
        /*
        Hier moet een referentie komen naar bullet BOWIE
        een referentie naar de enemy ROBBERT

        if pleyer/enemy ded dan naar de volgende state (loseState)
        */
    }
    public void Exit()
    {
        Debug.Log("exiting state");
    }
}