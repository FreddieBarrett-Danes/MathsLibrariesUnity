using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public GameObject[] PickUps;

    public GameObject RedPickUp;
    public GameObject BluePickUp;
    public GameObject YellowPickUp;

    public bool red;
    public bool blue;
    public bool yellow;
    // Start is called before the first frame update
    void Start()
    {
        PickUps = GameObject.FindGameObjectsWithTag("PickUp");
        RedPickUp = GameObject.Find("RedPickUp");
        BluePickUp = GameObject.Find("BluePickUp");
        YellowPickUp = GameObject.Find("YellowPickUp");
    }

    // Update is called once per frame
    void Update()
    {
        //constantly updating bools to corrispond with the colliding class 
        red = RedPickUp.GetComponent<PickUpCollisions>().isRed;
        blue = BluePickUp.GetComponent<PickUpCollisions>().isBlue;
        yellow = YellowPickUp.GetComponent<PickUpCollisions>().isYellow;
        
        //checks status of booleans and disables/enables renderers of appropraite pickups
        if(red)
        {
            RedPickUp.GetComponent<Renderer>().enabled = false;
        }
        else if(!red)
        {
            RedPickUp.GetComponent<Renderer>().enabled = true;
        }

        if (yellow)
        {
            YellowPickUp.GetComponent<Renderer>().enabled = false;
        }
        else if (!yellow)
        {
            YellowPickUp.GetComponent<Renderer>().enabled = true;
        }

        if (blue)
        {
            BluePickUp.GetComponent<Renderer>().enabled = false;
        }
        else if (!blue)
        {
            BluePickUp.GetComponent<Renderer>().enabled = true;
        }
    }
}
