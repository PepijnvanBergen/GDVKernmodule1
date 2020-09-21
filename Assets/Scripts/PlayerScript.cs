
using UnityEngine;

public interface IPlayer
{
    void Move();
    void Run();
    void Shoot();
}

public class PlayerScript : IPlayer, IKillable
{
    InputManager MyIM = new InputManager();
    //Maximale afstand links = '-5' maximale afstand rechts = '5.'
    //Als de camera een grote heeft van '4.405995'

    private float _currentPosX;

    private float _maxPosRight;
    private float _maxPosLeft;
    private float _speed;

    private Vector3 _movePosR;
    private Vector3 _movePosL;

    private GameObject _PlayerPrefab;
    public void PlayerObject(GameObject _Player)
    {
        _Player = GameObject.Instantiate(_Player, new Vector3(1f, 1f), Quaternion.identity);
        _PlayerPrefab = _Player;
    }
    public void Move()
    {
        _speed = 1f;
    }
    public void Run()
    {
        _speed = 1.5f;
    }

    public void SpeedReverse()
    {
        _speed *= -1f;
    }

    public void Calculate()
    {
        
        _currentPosX = _PlayerPrefab.transform.position.x;

        _movePosR = new Vector3(_speed, 0f);
        _movePosL = new Vector3(-_speed, 0f);

        //Beweeg naar rechts als de positie binnen de clamp valt.
        if (MyIM.moveInput.x > 0 && (_currentPosX < _maxPosRight))
        {
            _PlayerPrefab.transform.Translate(_movePosR * Time.deltaTime);
        }
        //Beweeg naar links als de positie binnen de clamp valt.
        if (MyIM.moveInput.x < 0 && (Mathf.Clamp(_currentPosX, _maxPosLeft, _maxPosRight) > _maxPosLeft))
        {
            _PlayerPrefab.transform.Translate(_movePosL * Time.deltaTime);
        }
    }
    public void Shoot()
    {
        //Hier de link naar bowies schiet functie.
    }
    public void Kill(GameObject obj)
    {
        GameObject.Destroy(_PlayerPrefab);
    }
}
