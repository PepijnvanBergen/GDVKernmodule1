using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void MyDelegate();
    List<GameObject> Bullets = new List<GameObject>();
    List<GameObject> Enemies = new List<GameObject>();

    [SerializeField] public GameObject bullet_prefab;
    [SerializeField] public GameObject enemy_prefab;

    public float range;
    public void SpawnBullet()
    {
        GameObject Bbullet = Instantiate(bullet_prefab, new Vector3(0,-4,0), Quaternion.identity);
        Bullets.Add(Bbullet);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject Eenemy = Instantiate(enemy_prefab, new Vector3(0, 4, 0), Quaternion.identity);
        Enemies.Add(Eenemy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SpawnBullet();
        }
        //Move all Bullets
        for (int i = 0; i < Bullets.Count; i++)
        {
            Bullets[i].transform.position = Bullets[i].transform.position + new Vector3(0, .01f, 0);
        }
        //Check Epic "Collision"
        for (int i = 0; i < Bullets.Count; i++)
        {
            Vector3 BulletPos = Bullets[i].transform.position;
            for (int y = 0; y < Enemies.Count; y++)
            {
                Vector3 EnemyPos = Enemies[i].transform.position;
                Vector3 Offset = BulletPos - EnemyPos;
                float sqrLen = Offset.sqrMagnitude;

                if (sqrLen < range * range)
                {
                    GameObject HitEnemy = Enemies[y];
                    Enemies.Remove(HitEnemy);
                    Destroy(HitEnemy);

                    GameObject HitBullet = Bullets[i];
                    Bullets.Remove(HitBullet);
                    Destroy(HitBullet);
                }
            }
        }
    }
}
