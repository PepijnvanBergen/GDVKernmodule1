using System.Collections;
using System.Collections.Generic;
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

    [SerializeField]
    private float _maxPosRight;
    [SerializeField]
    private float _maxPosLeft;
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _runSpeed;

    private Vector3 _movePosR;
    private Vector3 _movePosL;

    public GameObject Player;

    public void Move()
    {
        Calculate(_moveSpeed);
    }
    public void Run()
    {
        Calculate(_runSpeed);
    }
    public void Calculate(float speed)
    {
        
        _currentPosX = Player.transform.position.x;

        _movePosR = new Vector3(speed, 0f);
        _movePosL = new Vector3(-speed, 0f);

        //Beweeg naar rechts als de positie binnen de clamp valt.
        if (MyIM.moveInput.x > 0 && (_currentPosX < _maxPosRight))
        {
            Player.transform.Translate(_movePosR * Time.deltaTime);
        }
        //Beweeg naar links als de positie binnen de clamp valt.
        if (MyIM.moveInput.x < 0 && (Mathf.Clamp(_currentPosX, _maxPosLeft, _maxPosRight) > _maxPosLeft))
        {
            Player.transform.Translate(_movePosL * Time.deltaTime);
        }
    }
    public void Shoot()
    {
        //Hier de link naar bowies schiet functie.
    }
    public void Kill(GameObject obj)
    {
        //Die
    }
}
