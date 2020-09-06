using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillable 
{
    void Kill(GameObject obj);
}

public class Enemy : MonoBehaviour, IKillable
{
    [SerializeField]
    private GameObject player;

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
    private Sprite[] sprites;
    private int currentSprite = 0;
    private int maxSprites;


    [SerializeField]
    private float timer = 1f;
    private float nextTime;

    

    private void Start()
    {
        maxSprites = sprites.Length - 1;
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

            player.GetComponent<SpriteRenderer>().sprite = sprites[currentSprite];

            

            if (currentSprite != maxSprites)
                currentSprite += 1;
            else
                currentSprite = 0;
            
            if (currentStep < steps)
            {
                player.transform.position += new Vector3(horizontalStep * directionInt, 0, 0);
                currentStep++;
            }
            else
            {
                player.transform.position += new Vector3(0, -verticalStep, 0);
                directionInt *= -1;
                steps = maxSteps;
                currentStep = 0;
            }
        }
    }

    public void Kill(GameObject obj)
    {
        Destroy(obj);
    }
}
