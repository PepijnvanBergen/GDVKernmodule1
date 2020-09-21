using UnityEngine;

public class MoveState : IState
{
    //enemy myenemey = new enemy();
    //PlayerStateMachine MyPFSM = new PlayerStateMachine();
    //Bullet MyB;

    float timer = 1;
    float timeLeft;

    Enemy _enemy;

    public void Enter()
    {
        //MyB = new Bullet();
        //MyPFSM.ChangePlayerState(new PlayerShootState());

        _enemy = new Enemy();

        Debug.Log("entering move state");
    }
    public void Execute()
    {
        //myenemy.move();
        Debug.Log("execute move state");
        //MyPFSM.RunPlayerState();
        //MyB.BulletUpdate();

        //MyFSM.ChangeState(new DefeatState());
        //MyFSM.ChangeState(new WinState());
        /*
        Hier moet een referentie komen naar bullet BOWIE
        een referentie naar de enemy ROBBERT

        if pleyer/enemy ded dan naar de volgende state (loseState)
        */

        EnemyWalk();
    }

    private void EnemyWalk()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            for (int i = 0; i < Bullet.Enemies.Count; i++)
            {
                _enemy.Walk(Bullet.Enemies[i]);
            }

            Enemy.currentStep++;
            Debug.Log(Enemy.currentStep + " " + Enemy._steps);
            if (Enemy.currentStep > Enemy._steps)
            {
                _enemy.ReverseDirection();
            }

            timeLeft = timer;
        }
    }

    public void Exit()
    {
        Debug.Log("exiting move state");
    }
}