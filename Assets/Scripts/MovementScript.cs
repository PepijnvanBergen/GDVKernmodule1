using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    //Maximale afstand links = '-5' maximale afstand rechts = '5.'
    //Als de camera een grote heeft van '4.405995'
    private float Horizontal;
    private float currentPosX;
    public float MoveSpeed;

    [SerializeField]
    private float maxPosRight;
    [SerializeField]
    private float maxPosLeft;

    private Vector3 movePosR;
    private Vector3 movePosL;

    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        //Axis input
        Horizontal = Input.GetAxisRaw("Horizontal");

        currentPosX = Player.transform.position.x;

        //De movespeed omzetten in een vector voor de transfor.Translate
        movePosR = new Vector3(MoveSpeed, 0f);
        movePosL = new Vector3(-MoveSpeed, 0f);

        //Beweeg naar rechts als de positie binnen de clamp valt.
        if (Horizontal > 0 && (Mathf.Clamp(currentPosX, maxPosLeft, maxPosRight) < maxPosRight))
        {
            Player.transform.Translate(movePosR * Time.deltaTime);
        }
        //Beweeg naar links als de positie binnen de clamp valt.
        if(Horizontal < 0 && (Mathf.Clamp(currentPosX, maxPosLeft, maxPosRight) > maxPosLeft))
        {
            Player.transform.Translate(movePosL * Time.deltaTime);
        }
    }
}
