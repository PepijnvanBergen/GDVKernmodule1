using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillable 
{
    void Kill(GameObject obj);
}

public class Enemy : IKillable
{
    public static int _steps = 4;
    private int _maxSteps = 8;
    public static int currentStep;
    private int _directionInt = 1;

    [SerializeField]
    private float _horizontalStep = 1;
    [SerializeField]
    private float _verticalStep = 1;

    public void Walk(GameObject enemy)
    {
            
        if (currentStep < _steps)
        {
            enemy.transform.position += new Vector3(_horizontalStep * _directionInt, 0, 0);
        }
        else
        {
            enemy.transform.position += new Vector3(0, -_verticalStep, 0);
        }
    }

    public void ReverseDirection()
    {
        _directionInt *= -1;
        _steps = _maxSteps;
        currentStep = 0;
    }

    public void Kill(GameObject obj)
    {
        Object.Destroy(obj);
    }
}
