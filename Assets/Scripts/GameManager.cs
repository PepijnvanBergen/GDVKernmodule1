using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bulletPrefab;
    public GameObject playerPrefab;
    private Bullet MyB;
    PlayerScript MyPS = new PlayerScript();
    //PlayerStateMachine MyPFSM;// = new PlayerStateMachine();
    InputManager MyIM = new InputManager();

    [Header("Enemy")]
    public GameObject enemy;
    void Start()
    {
        StateMachine.ChangeState(new SpawnState());

        //MyPFSM.ChangePlayerState(new PlayerIdleState());
        MyB = new Bullet(enemyPrefab, bulletPrefab, MyPS);
        EventManager.SubscribeToEvent(EventEnum.ON_SHOOT, MyB.SpawnBullet);
        //MyPFSM.ChangePlayerState(new PlayerMoveState());
    }
    void Update()
    {
        MyIM.InputUpdate();
        StateMachine.RunState();
        MyB.BulletUpdate();
    }
}
