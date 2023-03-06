using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPickUpColour : MonoBehaviour
{
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        //finds which game object is attached to this script at the start of running and sets it appropriately
        if (gameObject.name == "RedPickUp")
        {
            rend.material.SetColor("_Color", Color.red);
        }
        else if (gameObject.name == "YellowPickUp")
        {
            rend.material.SetColor("_Color", Color.yellow);
        }
        else if (gameObject.name == "BluePickUp")
        {
            rend.material.SetColor("_Color", Color.blue);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
