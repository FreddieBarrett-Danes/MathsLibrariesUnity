using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABB : MonoBehaviour
{
    public Vector3 minExtent;
    public Vector3 maxExtent;

    //setting up properties of each box to determine the constraints of the object
    public float Top
    {
        get
        {
            return maxExtent.y + transform.position.y;
        }
    }
    public float Bottom
    {
        get
        {
            return minExtent.y + transform.position.y;
        }
    }
    public float Right
    {
        get
        {
            return maxExtent.x + transform.position.x;
        }
    }
    public float Left
    {
        get
        {
            return minExtent.x + transform.position.x;
        }
    }
    public float Front
    {
        get
        {
            return maxExtent.z + transform.position.z;
        }
    }
    public float Back
    {
        get
        {
            return minExtent.z + transform.position.z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        AABB[] boxes = FindObjectsOfType<AABB>();

        //checks each collider in the scene
        foreach (AABB box in boxes)
        {
            if (box != this)
            {
                //listens for intersection between this object and another box
                if (Intersects(this, box))
                {
                    //checks if the other object is of specific type
                    if(box.gameObject.tag == "ColourChanger")
                    {
                        //changes colour of other object to this game object and destroys itself
                        box.gameObject.GetComponent<Renderer>().material.SetColor("_Color", this.gameObject.GetComponent<Renderer>().material.color);
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }

    //checking if overlaps between the two boxs checking each edge of the cube's
    public static bool Intersects(AABB Box1, AABB Box2)
    {
        return !(Box2.Left > Box1.Right
            || Box2.Right < Box1.Left
            || Box2.Top < Box1.Bottom
            || Box2.Bottom > Box1.Top
            || Box2.Back > Box1.Front
            || Box2.Front < Box1.Back);
    }
}
