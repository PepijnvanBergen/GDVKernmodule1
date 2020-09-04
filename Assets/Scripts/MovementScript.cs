using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    //Maximale afstand links = '-5' maximale afstand rechts = '5.'
    //Als de camera een grote heeft van '5.395061'
    private float Horizontal;
    private float currentPosX;
    public float MoveSpeed;


    public float maxPosRight;
    public float maxPosLeft;

    private bool moveLeft = true;
    private bool moveRight = true;

    private Vector3 movePosR;
    private Vector3 movePosL;

    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        //Axis input
        Horizontal = Input.GetAxisRaw("Horizontal");

        //De movespeed omzetten in een vector voor de transfor.Translate
        movePosR = new Vector3(MoveSpeed, 0f);
        movePosL = new Vector3(-MoveSpeed, 0f);

        //Beweeg naar rechts
        if (Horizontal > 0 && moveRight == true)
        {
            Player.transform.Translate(movePosR * Time.deltaTime);
        }
        //Beweeg naar links
        if(Horizontal < 0 && moveLeft == true)
        {
            Player.transform.Translate(movePosL * Time.deltaTime);
        }

        //De huidige posite van de speler voor collision
        currentPosX = Player.transform.position.x;

        //Check of hij tegen de muur aan komt en zorg er dan voor dat hij niet verder kan gaan.
        if (currentPosX >= maxPosRight)
        {
            moveRight = false;
        }
        else
        {
            moveRight = true;
        }

        if(currentPosX <= maxPosLeft)
        {
            moveLeft = false;
        }
        else
        {
            moveLeft = true;
        }

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("horizontal = " + Horizontal);
        }
    }
}
