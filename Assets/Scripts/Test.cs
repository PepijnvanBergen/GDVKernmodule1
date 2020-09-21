using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField]
    private GameObject enemy;

    public static List<GameObject> enemies = new List<GameObject>();

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

    SpawnEnemies _spawnEnemies;
    Enemy _enemy;

    void Start()
    {
        _spawnEnemies = new SpawnEnemies(enemy, _rowAmount, _enemiesInRow, _rowLocationX, _rowLocationY, _nextRowLocationX, _nextEnemyPosY);
        _enemy = new Enemy();

        StartCoroutine(EnemyWalk());
    }

    private IEnumerator EnemyWalk()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            for (int i = 0; i < enemies.Count; i++)
            {
                _enemy.Walk(enemies[i]);
            }

            Enemy.currentStep++;
            Debug.Log(Enemy.currentStep + " " + Enemy._steps );
            if(Enemy.currentStep > Enemy._steps)
            {
                Debug.Log("sdasd");
                _enemy.ReverseDirection();
            }
        }
    }
}
