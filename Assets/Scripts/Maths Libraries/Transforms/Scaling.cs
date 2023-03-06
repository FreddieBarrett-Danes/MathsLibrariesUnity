using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{
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

        Matrix4by4 scaleMatrix = new Matrix4by4(new Vector3(1, 0, 0) * 2.0f, new Vector3(0, 1, 0), new Vector3(0, 0, 1), Vector3.zero);

        for(int i = 0; i< TransformedVertices.Length; i++)
        {
            TransformedVertices[i] = scaleMatrix * ModelSpaceVertices[i];
        }

        MeshFilter MF = GetComponent<MeshFilter>();

        MF.mesh.vertices = TransformedVertices;

        //These final steps are sometimes necessary to make the mesh look correct
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
