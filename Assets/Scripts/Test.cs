using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField]
    private GameObject enemy;

    [Header("Row Properties")]
    [SerializeField]
    private int _rowAmount;
    [SerializeField]
    private int _enemiesInRow;

    [Space]
    [SerializeField]
    private int _rowLocationX;
    [SerializeField]
    private int _rowLocationY;

    [Space]
    [SerializeField]
    private int _nextRowLocationX;
    [SerializeField]
    private int _nextEnemyPosY;

    float timer = 1;
    float timeLeft;

    SpawnEnemies _spawnEnemies;
    Enemy _enemy;

    void Start()
    {
        enemy = Resources.Load<GameObject>("Prefabs/Invader1");

        _spawnEnemies = new SpawnEnemies(enemy, _rowAmount, _enemiesInRow, _rowLocationX, _rowLocationY, _nextRowLocationX, _nextEnemyPosY);
        _enemy = new Enemy();
    }

    private void Update()
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
            Debug.Log(Enemy.currentStep + " " + Enemy._steps);
            if (Enemy.currentStep > Enemy._steps)
            {
                _enemy.ReverseDirection();
            }

            timeLeft = timer;
        }
    }
}
