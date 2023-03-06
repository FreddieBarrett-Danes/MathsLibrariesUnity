using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingSphere : MonoBehaviour
{
    public Vector3 CentrePoint;
    public float Radius = 1.0f;

    // Update is called once per frame
    void Update()
    {
        
        CentrePoint = transform.position;
        BoundingSphere[] allSpheresInScene = FindObjectsOfType<BoundingSphere>();

        //checks each sphere in the scene
        foreach (BoundingSphere c in allSpheresInScene)
        {
            if (c != this)
            {
                //listens for intersection between this object and another sphere
                if (Intersects(c))
                {
                    //checks if the other object is of specific type
                    if (c.gameObject.tag == "ColourChanger")
                    {
                        // changes colour of other object to this game object and destroys itself
                        c.gameObject.GetComponent<Renderer>().material.SetColor("_Color", this.gameObject.GetComponent<Renderer>().material.color);
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
    public bool Intersects(BoundingSphere otherSphere)
    {
        //checks distance between centre points of spheres
        Vector3 VectorToOtherSphere = otherSphere.CentrePoint - CentrePoint;

        float CombinedRadiusSq = otherSphere.Radius + Radius;
        CombinedRadiusSq *= CombinedRadiusSq;

        //checks if sphere edge is coliding with othe sphere edge
        return VectorToOtherSphere.sqrMagnitude <= CombinedRadiusSq;
    }
}
