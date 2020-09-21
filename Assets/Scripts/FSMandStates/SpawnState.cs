using UnityEngine;

public class SpawnState : IState
{
    private GameObject playerPrefab, enemy;

    private int _rowAmount = 5;
    private int _enemiesInRow = 5;

    private int _rowLocationX = -4;
    private int _rowLocationY = 0;

    private int _nextRowLocationX = 2;
    private int _nextEnemyPosY = 5;

    PlayerScript MyPS = new PlayerScript();
    SpawnEnemies _spawnEnemies;

    public void Enter()
    {
        Debug.Log("entering spawn state");

        playerPrefab = Resources.Load<GameObject>("Prefabs/Ship");
        enemy = Resources.Load<GameObject>("Prefabs/Invader1");

        MyPS.PlayerObject(playerPrefab);

        _spawnEnemies = new SpawnEnemies(enemy, _rowAmount, _enemiesInRow, _rowLocationX, _rowLocationY, _nextRowLocationX, _nextEnemyPosY);
    }

    public void Execute()
    {
        Debug.Log("execute spawn state");
        StateMachine.ChangeState(new MoveState());
    }

    public void Exit()
    {
        Debug.Log("exiting spawn state");
    }
}
