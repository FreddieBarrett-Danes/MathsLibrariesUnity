using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // this is needed to be moved across to my own transform AND euler
    public float mouseSensitivity = 100.0f;

    private MyTransform playerTransform;
    public MyTransform orientTransform;
    public Transform cameraTransform;
    

    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<MyTransform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //update orientation child
        orientTransform.Position = playerTransform.Position;
        

        //update camera 
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;
        
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        //creates a quaternion using my class using the y of the mouse
        MyVector3 playerRot = new MyVector3(0, yRotation, 0);
        Quat newPos = new Quat(playerRot);



        orientTransform.Rotation = newPos.GetAxis().ToUnityVector();
        cameraTransform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        //updates camera position
        Vector3 cameraPos = cameraTransform.position;
        cameraPos.x = orientTransform.Position.x;
        cameraPos.y = orientTransform.Position.y + 0.72f;
        cameraPos.z = orientTransform.Position.z;
        cameraTransform.position = cameraPos;
        
        
    }
}
