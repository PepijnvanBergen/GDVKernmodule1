using UnityEngine;

public class MoveState : IState
{
    float timer = 1;
    float timeLeft;

    Enemy _enemy;

    public void Enter()
    {
        _enemy = new Enemy();
    }
    public void Execute()
    {
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
            if (Enemy.currentStep > Enemy._steps)
            {
                _enemy.ReverseDirection();
            }

            timeLeft = timer;
        }
    }
    public void Exit()
    {
    }
}