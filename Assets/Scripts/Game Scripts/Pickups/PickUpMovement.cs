using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMovement : MonoBehaviour
{
    private MyVector3 rightTarget;
    private MyVector3 leftTarget;

    private MyVector3 forwardTarget;
    private MyVector3 backwardTarget;

    private MyVector3 diagonalupTarget;
    private MyVector3 diagonaldownTarget;

    private MyVector3 rightTrigger;
    private MyVector3 leftTrigger;

    private MyVector3 forwardTrigger;
    private MyVector3 backwardTrigger;

    private MyVector3 diagonalupTrigger;
    private MyVector3 diagonaldownTrigger;

    public MyVector3 direction = new MyVector3(0.0f, 0.0f, 0.0f);

    public MyVector3 currentVector;

    public MyVector3 chaseVelocity;

    private GameObject RedPickUp;
    private GameObject YellowPickUp;
    private GameObject BluePickUp;

    public float distance;

    public bool movingRight = false;
    public bool movingDiagonalUp = false;
    public bool movingForward = false;

    // Start is called before the first frame update
    void Start()
    {
        /*
            Triggers have been set to speed up the process of going back and forth between the two positions,
            this is due to interpolation slwoing down as it reached its destination
        */

        //Get GameObject needed for if statements
        RedPickUp = GameObject.Find("RedPickUp");
        YellowPickUp = GameObject.Find("YellowPickUp");
        BluePickUp = GameObject.Find("BluePickUp");

        //set distance and direction for object to move left/right
        rightTarget = new MyVector3(transform.position.x + distance, transform.position.y, transform.position.z);
        leftTarget = new MyVector3(transform.position.x - distance, transform.position.y, transform.position.z);

        //to trigger going right/left
        rightTrigger = new MyVector3(transform.position.x + distance - 0.5f, transform.position.y, transform.position.z);
        leftTrigger = new MyVector3(transform.position.x - distance + 0.5f, transform.position.y, transform.position.z);

        //set distance and direction for object to move forward/back
        forwardTarget = new MyVector3(transform.position.x, transform.position.y, transform.position.z + distance);
        backwardTarget = new MyVector3(transform.position.x, transform.position.y, transform.position.z - distance);

        //to trigger going forward/back
        forwardTrigger = new MyVector3(transform.position.x, transform.position.y, transform.position.z + distance - 0.5f);
        backwardTrigger = new MyVector3(transform.position.x, transform.position.y, transform.position.z - distance + 0.5f);

        //set distance and direction for object to move diagonally
        diagonalupTarget = new MyVector3(transform.position.x + distance, transform.position.y, transform.position.z + distance);
        diagonaldownTarget = new MyVector3(transform.position.x - distance, transform.position.y, transform.position.z - distance);

        //to trigger going diagonally
        diagonalupTrigger = new MyVector3(transform.position.x + distance - 0.5f, transform.position.y, transform.position.z + distance - 0.5f);
        diagonaldownTrigger = new MyVector3(transform.position.x - distance + 0.5f, transform.position.y, transform.position.z - distance + 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        PositionCheck();
        Move();
    }
    private void PositionCheck()
    {
        //gets current vector of gameobject attached to the script
        currentVector = new MyVector3(transform.position.x, transform.position.y, transform.position.z);

        //checks which gameobject is attached and then find out which direction it needs to move
        if (gameObject == RedPickUp)
        {
            if (currentVector.x >= rightTrigger.x)
            {
                movingRight = false;
            }
            else if (currentVector.x <= leftTrigger.x)
            {
                movingRight = true;
            }
        }

        if (gameObject == YellowPickUp)
        {
            if (currentVector.x >= diagonalupTrigger.x && currentVector.z >= diagonalupTrigger.x)
            {
                movingDiagonalUp = false;
            }
            else if (currentVector.x <= diagonaldownTrigger.x && currentVector.z <= diagonaldownTrigger.z)
            {
                movingDiagonalUp = true;
            }
        }

        if (gameObject == BluePickUp)
        {
            if (currentVector.z >= forwardTrigger.z)
            {
                movingForward = false;
            }
            else if (currentVector.z <= backwardTrigger.z)
            {
                movingForward = true;
            }
        }
    }
    private void Move()
    {
        //checks the game object script is attached to, then what direction that game object is mobing and then applies interpolation to desired target depending on which direction it needs to move
        if (gameObject == RedPickUp)
        {
            if (movingRight == true)
            {
                transform.position = MathsLibrary.VectorLerp(transform.position, rightTarget.ToUnityVector(), Time.deltaTime);
            }
            else if (movingRight == false)
            {
                transform.position = MathsLibrary.VectorLerp(transform.position, leftTarget.ToUnityVector(), Time.deltaTime);
            }
        }
        else if(gameObject == YellowPickUp)
        {
            if (movingDiagonalUp == true)
            {
                transform.position = MathsLibrary.VectorLerp(transform.position, diagonalupTarget.ToUnityVector(), Time.deltaTime);
            }
            else if (movingDiagonalUp == false)
            {
                transform.position = MathsLibrary.VectorLerp(transform.position, diagonaldownTarget.ToUnityVector(), Time.deltaTime);
            }
        }
        else if (gameObject == BluePickUp)
        {
            if (movingForward == true)
            {
                transform.position = MathsLibrary.VectorLerp(transform.position, forwardTarget.ToUnityVector(), Time.deltaTime);
            }
            else if (movingForward == false)
            {
                transform.position = MathsLibrary.VectorLerp(transform.position, backwardTarget.ToUnityVector(), Time.deltaTime);
            }
        }


    }
}
