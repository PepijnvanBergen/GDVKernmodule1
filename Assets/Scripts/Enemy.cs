using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillable 
{
    void Kill(GameObject obj);
}

public class Enemy : IKillable
{
    private int _steps = 5;
    private int _maxSteps;
    public int currentStep;
    private int _directionInt = 1;

    [SerializeField]
    private float _horizontalStep = 1;
    [SerializeField]
    private float _verticalStep = 1;

    private float _timer = 1f;
    private float _nextTime;

    public void Walk(GameObject enemy)
    {
        _maxSteps = _steps * 2;
            
        if (currentStep < _steps)
        {
            enemy.transform.position += new Vector3(_horizontalStep * _directionInt, 0, 0);
        }
        else
        {
            enemy.transform.position += new Vector3(0, -_verticalStep, 0);
            _directionInt *= -1;
            _steps = _maxSteps;
            currentStep = 0;
        }
    }

    public void Kill(GameObject obj)
    {
        Object.Destroy(obj);
    }
}
