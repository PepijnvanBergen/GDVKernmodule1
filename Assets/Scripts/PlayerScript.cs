
using UnityEngine;

public interface IPlayer
{
    void MoveR();
    void MoveL();
    void RunR();
    void RunL();
    void Shoot();
}

public class PlayerScript : IPlayer, IKillable
{
    //Maximale afstand links = '-5' maximale afstand rechts = '5.'
    //Als de camera een grote heeft van '4.405995'

    private float _maxPosRight = 5f;
    private float _maxPosLeft = -5f;

    private Vector3 _movePos;
    public static Vector3 playerPos;

    public GameObject _PlayerPrefab;
    //public Vector3 PlayerPos = new Vector3(3,0,0);

    public void PlayerObject(GameObject _player)
    {
        _player = GameObject.Instantiate(_player);
        _PlayerPrefab = _player;


        EventManager.SubscribeToEvent(EventEnum.ON_IDLE, Idle);
        EventManager.SubscribeToEvent(EventEnum.ON_MOVEL, MoveL);
        EventManager.SubscribeToEvent(EventEnum.ON_MOVER, MoveR);
        EventManager.SubscribeToEvent(EventEnum.ON_RUNL, RunL);
        EventManager.SubscribeToEvent(EventEnum.ON_RUNR, RunR);
    }

    public void Idle()
    {
        Calculate(0);
        //Debug.Log("idle");
    }
    public void Shoot()
    {
        //_MyB.SpawnBullet();
        Calculate(0f);

        Debug.Log("Piew");
    }
    public void MoveR()
    {
        Calculate(2.5f);
    }
    public void MoveL()
    {
        Calculate(-2.5f);
    }
    public void RunR()
    {
        Calculate(5f);
    }
    public void RunL()
    {
        Calculate(-5f);
    }


    public void Calculate(float _speed)
    {
        float _posX;
        Vector3 _vectorPos;

        _movePos = new Vector3(_speed, 0f);

        _posX = _PlayerPrefab.transform.position.x;
        _posX = Mathf.Clamp(_posX, -9, 9);

        _vectorPos.x = _posX;
        _PlayerPrefab.transform.position = new Vector3(_posX, -4);

        //Beweeg als de positie binnen de clamp valt.
        _PlayerPrefab.transform.Translate(_movePos * Time.deltaTime);

        playerPos = _PlayerPrefab.transform.position;
    }
    public void Kill(GameObject obj)
    {
        GameObject.Destroy(_PlayerPrefab);
    }
}
