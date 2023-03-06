using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollisions : MonoBehaviour
{
    private GameObject Player;

    private GameObject controller;
    private PickUpController pController;

    private float timer = 10.0f;
    private float originalTimer;

    public bool isRed = false;
    public bool isYellow = false;
    public bool isBlue = false;

    public bool redColliding = false;
    public bool yellowColliding = false;
    public bool blueColliding = false;
    // Start is called before the first frame update
    void Start()
    {
        //stores original timer value to reset when required
        originalTimer = timer;

        Player = GameObject.FindGameObjectWithTag("Player");

        controller = GameObject.FindGameObjectWithTag("PickUpController");
        pController = controller.GetComponent<PickUpController>();
    }

    // Update is called once per frame
    void Update()
    {
        //checks each colliding bool to set a bool which controller is listening for and sets the timer to original duration
        //then checks if it is no longer colliding, starts counting timer down, when timer hits zero sets bool back to false to reset colour to white
        if(redColliding)
        {
            isRed = true;
            timer = originalTimer;
        }
        else if(!redColliding)
        {

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isRed = false;

            }
        }

        if (yellowColliding)
        {
            isYellow = true;
            timer = originalTimer;
        }
        else if (!yellowColliding)
        {

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isYellow = false;
            }
        }

        if (blueColliding)
        {
            isBlue = true;
            timer = originalTimer;
        }
        else if (!blueColliding)
        {

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isBlue = false;
            }
        }
    }
    //checks if the player has walked into the pickup and then set a boolean as appropriate depending on pickup
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == Player && gameObject.name == "RedPickUp")
        {
            redColliding = true;
        }
        else if (collision.gameObject == Player && gameObject.name == "YellowPickUp")
        {
            yellowColliding = true;
        }
        else if (collision.gameObject == Player && gameObject.name == "BluePickUp")
        {
            blueColliding = true;
        }
    }
    //checks if the player has walked out of the pickup and then set a boolean as appropriate depending on pickup
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == Player && gameObject.name == "RedPickUp")
        {
            redColliding = false;
        }
        else if (collision.gameObject == Player && gameObject.name == "YellowPickUp")
        {
            yellowColliding = false;
        }
        else if (collision.gameObject == Player && gameObject.name == "BluePickUp")
        {
            blueColliding = false;
        }
    }
}
