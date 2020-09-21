using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bulletPrefab;
    public GameObject playerPrefab;
    Bullet MyB;
    PlayerScript MyPS = new PlayerScript();
    //PlayerStateMachine MyPFSM;// = new PlayerStateMachine();
    InputManager MyIM = new InputManager();

    [Header("Enemy")]
    public GameObject enemy;

    // Start is called before the first frame update
    private void Awake()
    {
        //MyPS = GetComponent < PlayerScript>();
    }
    void Start()
    {
        StateMachine.ChangeState(new SpawnState());
        MyPS.PlayerObject(playerPrefab, MyB);
        //MyPFSM.ChangePlayerState(new PlayerIdleState());
        MyB = new Bullet(enemyPrefab, bulletPrefab, MyPS);
        EventManager.SubscribeToEvent(EventEnum.ON_SHOOT, MyB.SpawnBullet);
        //MyPFSM.ChangePlayerState(new PlayerMoveState());
    }
    void Update()
    {
        MyIM.InputUpdate();
        MyB.BulletUpdate();
        StateMachine.RunState();
    }
}
