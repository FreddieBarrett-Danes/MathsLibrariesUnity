using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    Vector3[] ModelSpaceVertices;
    float Angle = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter MF = GetComponent<MeshFilter>();

        ModelSpaceVertices = MF.mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        Angle += Time.deltaTime;
        Vector3[] TransformedVertices = new Vector3[ModelSpaceVertices.Length];

        //Roll Matrix Z axis
        Matrix4by4 rollMatrix = new Matrix4by4(
            new Vector3(Mathf.Cos(Angle), Mathf.Sin(Angle), 0),
            new Vector3(-Mathf.Sin(Angle), Mathf.Cos(Angle), 0),
            new Vector3(0, 0, 1),
            Vector3.zero);

        //Pitch Matrix X axis
        Matrix4by4 pitchMatrix = new Matrix4by4(
            new Vector3(1, 0, 0),
            new Vector3(0, Mathf.Cos(Angle), Mathf.Sin(Angle)),
            new Vector3(0, -Mathf.Sin(Angle), Mathf.Cos(Angle)),
            Vector3.zero);

        //Yaw Matrix Y axis
        Matrix4by4 yawMatrix = new Matrix4by4(new Vector3(Mathf.Cos(Angle), 0, -Mathf.Sin(Angle)), 
            new Vector3(0, 1, 0), 
            new Vector3(Mathf.Sin(Angle), 0, Mathf.Cos(Angle)), 
            new Vector3(0, 0, 0));


        Matrix4by4 R = yawMatrix * (pitchMatrix * rollMatrix);

        for (int i =0; i < TransformedVertices.Length; i++)
        {
            TransformedVertices[i] = R * ModelSpaceVertices[i];
        }
        
        MeshFilter MF = GetComponent<MeshFilter>();

        MF.mesh.vertices = TransformedVertices;
    }
}
