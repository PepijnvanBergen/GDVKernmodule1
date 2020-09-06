using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int steps;
    private int maxSteps;
    private int currentStep = 0;
    private int directionInt = 1;

    [SerializeField]
    private float horizontalStep;
    [SerializeField]
    private float verticalStep;

    [SerializeField]
    private Sprite[] _sprites;
    private int _currentSprite = 0;
    private int _maxSprites;


    [SerializeField]
    private float timer = 1f;
    private float nextTime;

    private void Start()
    {
        _maxSprites = _sprites.Length - 1;
        maxSteps = steps * 2;
    }

    private void Update()
    {
        Walk(timer);
    }

    void Walk(float actionTime)
    {
        if(Time.time >= nextTime)
        {
            nextTime += actionTime;

            GetComponent<SpriteRenderer>().sprite = _sprites[_currentSprite];

            if (_currentSprite != _maxSprites)
                _currentSprite += 1;
            else
                _currentSprite = 0;
            
            if (currentStep < steps)
            {
                transform.position += new Vector3(horizontalStep * directionInt, 0, 0);
                currentStep++;
            }
            else
            {
                transform.position += new Vector3(0, -verticalStep, 0);
                directionInt *= -1;
                steps = maxSteps;
                currentStep = 0;
            }
        }
    }
}
