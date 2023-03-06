using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTransformUpdate : MonoBehaviour
{
    public MyTransform playerTransform;
    private Transform objectTransform;

    public float originalPosX;
    public float originalPosY;
    public float originalPosZ;
    
    public float originalRotX;
    public float originalRotY;
    public float originalRotZ;

    // Start is called before the first frame update
    void Start()
    {
        objectTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * as MyTransform class doesn't update objects positions that are childs of those being updated and while 
         * I need some properties inside of the Unity.Transform class I update the Unity.Transform with MyTransform class
         * in order to access these properties and still be relevant to the parent object's position and relevant 
        */

        Vector3 pos = objectTransform.position;
        pos.x = originalPosX + playerTransform.Position.x;
        pos.y = originalPosY + playerTransform.Position.y;
        pos.z = originalPosZ + playerTransform.Position.z;
        objectTransform.position = pos;

        objectTransform.rotation = Quaternion.Euler(playerTransform.Rotation.x, playerTransform.Rotation.y, playerTransform.Rotation.z);
    }
}
