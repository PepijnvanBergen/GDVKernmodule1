using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void MyDelegate();
    public static MyDelegate Bullets;
    
    public void SpawnBullet()
    {
        Debug.Log("Spawn Bullet");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SpawnBullet();
        }
    }
}
