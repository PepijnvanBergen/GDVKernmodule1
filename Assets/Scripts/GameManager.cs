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
    PlayerStateMachine MyPFSM = new PlayerStateMachine();
    // Start is called before the first frame update
    void Start()
    {
        MyPS.PlayerObject(playerPrefab);
        MyB = new Bullet(enemyPrefab, bulletPrefab);
        //MyPFSM.ChangePlayerState(new PlayerMoveState());
    }

    // Update is called once per frame
    void Update()
    {
        MyB.BulletUpdate();
        MyPFSM.RunPlayerState();
    }
}
