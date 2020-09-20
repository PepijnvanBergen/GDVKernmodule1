using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void MyDelegate();
    public static MyDelegate Bullets;

    StateMachine MyFSM = new StateMachine();
    InputManager MyIM = new InputManager();

    public void SpawnBullet()
    {
        Debug.Log("Spawn Bullet");
    }

    // Start is called before the first frame update
    void Start()
    {
        MyFSM.ChangeState(new MoveState());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SpawnBullet();
        }
        MyFSM.RunState();
        MyIM.InputUpdate();
    }
}
