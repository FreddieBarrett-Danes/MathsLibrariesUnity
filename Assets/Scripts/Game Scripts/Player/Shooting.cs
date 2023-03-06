using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private GameObject BulletEmitter;

    public GameObject squareBullet;
    public GameObject circleBullet;

    public float speed;

    private GameObject controller;
    private PickUpController colour;

    public bool red;
    public bool yellow;
    public bool blue;

    void Start()
    {
        BulletEmitter = this.gameObject;

        controller = GameObject.FindGameObjectWithTag("PickUpController");
        colour = controller.GetComponent<PickUpController>();
    }

    // Update is called once per frame
    void Update()
    {
        //checks for LMB being pressed
        if (Input.GetMouseButtonDown(0))
        {
            GameObject TemporarySquareBullet;
            TemporarySquareBullet = Instantiate(squareBullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation) as GameObject;

            //checks what color is currently active via the controller class and setts the instatiated object to appropriate colour
            if (red)
            {
                TemporarySquareBullet.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
            else if (yellow)
            {
                TemporarySquareBullet.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
            else if (blue)
            {
                TemporarySquareBullet.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            }
            else
            {
                TemporarySquareBullet.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            }

            //TemporaryBullet.transform.Translate(transform.forward * speed * Time.deltaTime);

            Rigidbody TemporarySquareRigidbody;
            TemporarySquareRigidbody = TemporarySquareBullet.GetComponent<Rigidbody>();

            TemporarySquareRigidbody.AddForce(transform.forward * speed);

            Destroy(TemporarySquareBullet, 5.0f);
        }
        //checks for RMB being pressed
        else if (Input.GetMouseButtonDown(1))
        {
            GameObject TemporaryCircleBullet;
            TemporaryCircleBullet = Instantiate(circleBullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation) as GameObject;

            //checks what color is currently active via the controller class and setts the instatiated object to appropriate colour
            if (red)
            {
                TemporaryCircleBullet.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
            else if (yellow)
            {
                TemporaryCircleBullet.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
            else if (blue)
            {
                TemporaryCircleBullet.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            }
            else
            {
                TemporaryCircleBullet.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            }

            //TemporaryBullet.transform.Translate(transform.forward * speed * Time.deltaTime);

            Rigidbody TemporaryCircleRigidbody;
            TemporaryCircleRigidbody = TemporaryCircleBullet.GetComponent<Rigidbody>();

            TemporaryCircleRigidbody.AddForce(transform.forward * speed);

            Destroy(TemporaryCircleBullet, 5.0f);
        }
        CheckColour();
    }

    private void CheckColour()
    {
        //looks into controller script and updates the appropriate booleans
        red = colour.red;
        blue = colour.blue;
        yellow = colour.yellow;
    }  
}
