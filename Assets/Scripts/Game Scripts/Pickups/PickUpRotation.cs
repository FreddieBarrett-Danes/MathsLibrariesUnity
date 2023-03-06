using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRotation : MonoBehaviour
{
    private float Angle = 0.0f;
    private MyTransform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<MyTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //adds a angle to both the x and y axis which increases over time from the time of the artefact
        Angle += Time.deltaTime;

        myTransform.Rotation.y = Angle;
        myTransform.Rotation.x = Angle;
    }
}
