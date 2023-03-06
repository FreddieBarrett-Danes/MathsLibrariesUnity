using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public MyTransform myTransform;
    public Transform myOrientation;

    private CapsuleCollider playerCollider;

    public float speed;

    void Start()
    {
        playerCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //uses a child to player to find relative right/forward directions depending on whre the player is looking
        Vector3 move = (myOrientation.right * x + myOrientation.forward * z) * speed * Time.deltaTime;

        //applies the transform
        myTransform.Position += move;

        //Updates Collider Posiiton
        Vector3 playerCenter = playerCollider.center;
        playerCenter.x = myTransform.Position.x;
        playerCenter.y = myTransform.Position.y;
        playerCenter.z = myTransform.Position.z;
        playerCollider.center = playerCenter;
    }
}
