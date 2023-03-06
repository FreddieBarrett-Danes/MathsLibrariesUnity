using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MyTransform : MonoBehaviour
{
    public Vector3 Position = new Vector3(0, 0, 0);
    public Vector3 Rotation = new Vector3(0, 0, 0);
    public Vector3 Scale = new Vector3(1, 1, 1);

    Vector3[] ModelSpaceVertices;

    // Start is called before the first frame update
    void Start()
    {
        MeshFilter MF = GetComponent<MeshFilter>();

        ModelSpaceVertices = MF.mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] TransformedVertices = new Vector3[ModelSpaceVertices.Length];

        Matrix4by4 translationMatrix = new Matrix4by4(
          new MyVector3(1, 0, 0),
          new MyVector3(0, 1, 0),
          new MyVector3(0, 0, 1),
          new MyVector3(Position.x, Position.y, Position.z));

        Matrix4by4 scaleMatrix = new Matrix4by4(
            new MyVector3(Scale.x, 0, 0), 
            new MyVector3(0, Scale.y, 0), 
            new MyVector3(0, 0, Scale.z), 
            new MyVector3(0, 0, 0));

        //Pitch Matrix X axis
        Matrix4by4 pitchMatrix = new Matrix4by4(
            new MyVector3(1, 0, 0),
            new MyVector3(0, Mathf.Cos(Rotation.x), Mathf.Sin(Rotation.x)),
            new MyVector3(0, -Mathf.Sin(Rotation.x), Mathf.Cos(Rotation.x)),
            new MyVector3(0, 0, 0));

        //Yaw Matrix Y axis
        Matrix4by4 yawMatrix = new Matrix4by4(
            new MyVector3(Mathf.Cos(Rotation.y), 0, -Mathf.Sin(Rotation.y)),
            new MyVector3(0, 1, 0),
            new MyVector3(Mathf.Sin(Rotation.y), 0, Mathf.Cos(Rotation.y)),
            new MyVector3(0, 0, 0));

        //Roll Matrix Z axis
        Matrix4by4 rollMatrix = new Matrix4by4(
            new MyVector3(Mathf.Cos(Rotation.z), Mathf.Sin(Rotation.z), 0),
            new MyVector3(-Mathf.Sin(Rotation.z), Mathf.Cos(Rotation.z), 0),
            new MyVector3(0, 0, 1),
            new MyVector3(0, 0, 0));

        Matrix4by4 rotationMatrix = yawMatrix * (pitchMatrix * rollMatrix);

        Matrix4by4 M = translationMatrix * (rotationMatrix * scaleMatrix);

        for (int i = 0; i < TransformedVertices.Length; i++)
        {
            TransformedVertices[i] = M * ModelSpaceVertices[i];
        }

        MeshFilter MF = GetComponent<MeshFilter>();
        
        MF.mesh.vertices = TransformedVertices;
        
        //These final steps are sometimes necessary to make the mesh look correct
        //MF.mesh.RecalculateNormals();
        //MF.mesh.RecalculateBounds();
    }
}
