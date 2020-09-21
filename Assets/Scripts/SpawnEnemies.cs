using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies 
{
    int _nextPosX;
    int _nextPosY;

    public SpawnEnemies(GameObject enemy, int rowAmount, int enemiesInRow, int rowLocationX, int rowLocationY, int nextRowLocationX, int nextEnemyPosY)
    {
        for (int j = 0; j < rowAmount; j++)
        {
            for (int i = 0; i < enemiesInRow; i++)
            {
                GameObject go = GameObject.Instantiate(enemy, new Vector3(rowLocationX + _nextPosX, rowLocationY + _nextPosY, 0), Quaternion.identity);
                Bullet.Enemies.Add(go);

                _nextPosY ++;
            }
            _nextPosX += nextRowLocationX;
            _nextPosY -= nextEnemyPosY;
        }
    }
}
