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
    }

    private void Update()
    {
        //WERKT NIET :(
        //Debug.Log(enemies.Count);
        //for (int i = 0; i < enemies.Count; i++)
        //{
        //    _enemy.Walk(1, enemies[i]);
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Destroy(enemies[0]);
        //}
    }
}
