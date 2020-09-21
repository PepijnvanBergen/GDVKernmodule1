using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet
{
    List<GameObject> Bullets = new List<GameObject>();
    public static List<GameObject> Enemies = new List<GameObject>();

    private GameObject _enemyPrefab;
    private GameObject _bulletPrefab;

    private Vector3 _PlayerPos;

    public float range = 0.9f;
    public float firerate = 0.5f;

    private bool _cooldown = false;
    GameObject _player;
    //private PlayerScript _MyPS = new PlayerScript();

    public Bullet(GameObject _enemy, GameObject _bullet, PlayerScript _MyPS)
    {
        _player = _MyPS._PlayerPrefab;
        _enemyPrefab = _enemy;
        _bulletPrefab = _bullet;
        //GameObject Eenemy = GameObject.Instantiate(_enemyPrefab, new Vector3(0, 4, 0), Quaternion.identity);
        //Enemies.Add(Eenemy);
    }

    public void BulletUpdate()
    {
        //_PlayerPos = _player.transform.position;
        //_PlayerPos = _MyPS.
        //_PlayerPos = PlayerScript.PlayerPos;

        MoveBullets();
        HandleCollision();
    }
    public void SpawnBullet()
    {
        if (_cooldown == false)
        {
            //Cooldown = true;
            GameObject Bbullet = GameObject.Instantiate(_bulletPrefab, PlayerScript.playerPos, Quaternion.identity);
            Bullets.Add(Bbullet);

        }
    }
    public void MoveBullets()
    {
        //Move all Bullets
        for (int i = 0; i < Bullets.Count; i++)
        {
            Bullets[i].transform.position = Bullets[i].transform.position + new Vector3(0, .01f, 0);
        }
    }
    public void HandleCollision()
    {
        //Check Epic "Collision"
        for (int i = 0; i < Bullets.Count; i++)
        {
            Vector3 BulletPos = Bullets[i].transform.position;
            for (int y = 0; y < Enemies.Count; y++)
            {
                Vector3 EnemyPos = Enemies[y].transform.position;
                Vector3 Offset = BulletPos - EnemyPos;
                float sqrLen = Offset.sqrMagnitude;

                if (sqrLen < range * range)
                {
                    GameObject HitEnemy = Enemies[y];
                    Enemies.Remove(HitEnemy);
                    GameObject.Destroy(HitEnemy);

                    GameObject HitBullet = Bullets[i];
                    Bullets.Remove(HitBullet);
                    GameObject.Destroy(HitBullet);
                    //Or let the Enemy Take Damage so he can survive multiple Hits ;)
                }
            }
            if (BulletPos.y > 5)
            {
                GameObject HitBullet = Bullets[i];
                Bullets.Remove(HitBullet);
                GameObject.Destroy(HitBullet);
            }
        }
    }
}