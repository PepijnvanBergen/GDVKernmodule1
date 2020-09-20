using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void MyDelegate();
    public static MyDelegate Bullets;
    
    List<GameObject> Bullets = new List<GameObject>();
    List<GameObject> Enemies = new List<GameObject>();

    [SerializeField] public GameObject bullet_prefab;
    [SerializeField] public GameObject enemy_prefab;

    private Vector3 PlayerPos = new Vector3(0, -4, 0);

    public float range;
    public float firerate;

    private bool Cooldown = false;
    IEnumerator FireRateCooldown()
    {
        yield return new WaitForSeconds(firerate);
        Cooldown = false;
    }
    
    public void SpawnBullet()
    {
        if (Cooldown == false)
        {
            Cooldown = true;
            GameObject Bbullet = Instantiate(bullet_prefab, PlayerPos, Quaternion.identity);
            Bullets.Add(Bbullet);
            StartCoroutine("FireRateCooldown");
        }
    }

    public void Shoot()
    {
        if (Input.GetKeyDown("space"))
        {
            SpawnBullet();
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
                    Destroy(HitEnemy);

                    GameObject HitBullet = Bullets[i];
                    Bullets.Remove(HitBullet);
                    Destroy(HitBullet);
                    //Or let the Enemy Take Damage so he can survive multiple Hits ;)
                }
            }
            if (BulletPos.y > 5)
            {
                GameObject HitBullet = Bullets[i];
                Bullets.Remove(HitBullet);
                Destroy(HitBullet);
            }
        }
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
        Shoot();
        MoveBullets();
        HandleCollision();
    }
}