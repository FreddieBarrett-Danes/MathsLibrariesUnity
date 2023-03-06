using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathsLibrary
{
    public static float VectorToRadians(MyVector2 v)
    {
        float rValue = 0.0f;

        rValue = Mathf.Atan(v.y / v.x);

        return rValue;
    }
    public static MyVector2 RadiansToVector(float angle)
    {
        MyVector2 rValue = new MyVector2(Mathf.Cos(angle), Mathf.Sin(angle));

        return rValue;
    }
    //fiddle to make work with unity coordinate system
    public static MyVector3 EulerAnglesToDirection(Vector3 EulerAngles)
    {
        MyVector3 rValue = new MyVector3(0.0f, 0.0f, 0.0f);

        rValue.x = Mathf.Cos(EulerAngles.y) * Mathf.Cos(EulerAngles.x);
        rValue.y = Mathf.Sin(EulerAngles.x);
        rValue.z = Mathf.Cos(EulerAngles.x) * Mathf.Sin(EulerAngles.y);

        return rValue;
    }
    public static MyVector3 VectorCrossProduct(MyVector3 A, MyVector3 B)
    {
        MyVector3 rValue = new MyVector3(0, 0, 0);

        rValue.x = A.y * B.z - A.z * B.y;
        rValue.y = A.z * B.x - A.x * B.z;
        rValue.z = A.x * B.y - A.y * B.x;

        return rValue;
    }
    public static Vector3 VectorLerp(Vector3 a, Vector3 b, float t)
    {
        MyVector3 rValue = new MyVector3(0, 0, 0);
        
        rValue.x = a.x * (1.0f - t) + b.x * t;
        rValue.y = a.y * (1.0f - t) + b.y * t;
        rValue.z = a.z * (1.0f - t) + b.z * t;

        return rValue.ToUnityVector();
    }
    public static MyVector3 RotateVertex(float angle, MyVector3 Axis, MyVector3 Vertex)
    {
        MyVector3 rValue = Vertex * Mathf.Cos(angle) +
            Vertex * MyVector3.VectorDot(Vertex, Axis) * (1.0f - Mathf.Cos(angle)) +
            VectorCrossProduct(Axis, Vertex) * Mathf.Sin(angle);

        return rValue;
    } 
}
public class Matrix4by4
{
    public float[,] values;
    public static Matrix4by4 Identity
    {
        get
        {
            return new Matrix4by4(
                new MyVector4(1, 0, 0, 0),
                new MyVector4(0, 1, 0, 0),
                new MyVector4(0, 0, 1, 0),
                new MyVector4(0, 0, 0, 1));
        }
    }
    public Matrix4by4(MyVector4 column1, MyVector4 column2, MyVector4 column3, MyVector4 column4)
    {
        values = new float[4, 4];

        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z; 
        values[3, 0] = column1.w;

        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = column2.w;

        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = column3.w;

        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = column4.w;
    }
    public Matrix4by4(Vector4 column1, Vector4 column2, Vector4 column3, Vector4 column4)
    {
        values = new float[4, 4];

        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = column1.w;

        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = column2.w;

        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = column3.w;

        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = column4.w;
    }
    public Matrix4by4(MyVector3 column1, MyVector3 column2, MyVector3 column3, MyVector3 column4)
    {
        values = new float[4, 4];

        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = 0.0f;

        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = 0.0f;
        
        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = 0.0f;

        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = 1.0f;
    }
    public Matrix4by4(Vector3 column1, Vector3 column2, Vector3 column3, Vector3 column4)
    {
        values = new float[4, 4];

        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = 0.0f;

        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = 0.0f;

        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = 0.0f;

        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = 1.0f;
    }
    public static MyVector4 operator *(Matrix4by4 lhs, MyVector4 rhs)
    {
        MyVector4 rValue = new MyVector4(0, 0, 0, 0);

        rValue.x = lhs.values[0, 0] * rhs.x + lhs.values[0, 1] * rhs.y + lhs.values[0, 2] * rhs.z + lhs.values[0, 3] * rhs.w;
        rValue.y = lhs.values[1, 0] * rhs.x + lhs.values[1, 1] * rhs.y + lhs.values[1, 2] * rhs.z + lhs.values[1, 3] * rhs.w;
        rValue.z = lhs.values[2, 0] * rhs.x + lhs.values[2, 1] * rhs.y + lhs.values[2, 2] * rhs.z + lhs.values[2, 3] * rhs.w;
        rValue.w = lhs.values[3, 0] * rhs.x + lhs.values[3, 1] * rhs.y + lhs.values[3, 2] * rhs.z + lhs.values[3, 3] * rhs.w;

        return rValue;
    }
    public static Vector4 operator *(Matrix4by4 lhs, Vector3 rhs)
    {
        Vector4 rValue = new Vector4(0, 0, 0, 0);
        
        rValue.x = lhs.values[0, 0] * rhs.x + lhs.values[0, 1] * rhs.y + lhs.values[0, 2] * rhs.z + lhs.values[0, 3] * 1;
        rValue.y = lhs.values[1, 0] * rhs.x + lhs.values[1, 1] * rhs.y + lhs.values[1, 2] * rhs.z + lhs.values[1, 3] * 1;
        rValue.z = lhs.values[2, 0] * rhs.x + lhs.values[2, 1] * rhs.y + lhs.values[2, 2] * rhs.z + lhs.values[2, 3] * 1;
        rValue.w = lhs.values[3, 0] * rhs.x + lhs.values[3, 1] * rhs.y + lhs.values[3, 2] * rhs.z + lhs.values[3, 3] * 1;

        return rValue;
    }
    public static Matrix4by4 operator *(Matrix4by4 lhs, Matrix4by4 rhs)
    {
        Matrix4by4 rValue = new Matrix4by4(Vector4.zero, Vector4.zero, Vector4.zero, Vector4.zero);

        //try to change this to nested for loop

        //first row
        rValue.values[0, 0] = lhs.values[0, 0] * rhs.values[0, 0] + lhs.values[0, 1] * rhs.values[1, 0] + lhs.values[0, 2] * rhs.values[2, 0] + lhs.values[0, 3] * rhs.values[3, 0];
        rValue.values[0, 1] = lhs.values[0, 0] * rhs.values[0, 1] + lhs.values[0, 1] * rhs.values[1, 1] + lhs.values[0, 2] * rhs.values[2, 1] + lhs.values[0, 3] * rhs.values[3, 1];
        rValue.values[0, 2] = lhs.values[0, 0] * rhs.values[0, 2] + lhs.values[0, 1] * rhs.values[1, 2] + lhs.values[0, 2] * rhs.values[2, 2] + lhs.values[0, 3] * rhs.values[3, 2];
        rValue.values[0, 3] = lhs.values[0, 0] * rhs.values[0, 3] + lhs.values[0, 1] * rhs.values[1, 3] + lhs.values[0, 2] * rhs.values[2, 3] + lhs.values[0, 3] * rhs.values[3, 3];

        //second row
        rValue.values[1, 0] = lhs.values[1, 0] * rhs.values[0, 0] + lhs.values[1, 1] * rhs.values[1, 0] + lhs.values[1, 2] * rhs.values[2, 0] + lhs.values[1, 3] * rhs.values[3, 0];
        rValue.values[1, 1] = lhs.values[1, 0] * rhs.values[0, 1] + lhs.values[1, 1] * rhs.values[1, 1] + lhs.values[1, 2] * rhs.values[2, 1] + lhs.values[1, 3] * rhs.values[3, 1];
        rValue.values[1, 2] = lhs.values[1, 0] * rhs.values[0, 2] + lhs.values[1, 1] * rhs.values[1, 2] + lhs.values[1, 2] * rhs.values[2, 2] + lhs.values[1, 3] * rhs.values[3, 2];
        rValue.values[1, 3] = lhs.values[1, 0] * rhs.values[0, 3] + lhs.values[1, 1] * rhs.values[1, 3] + lhs.values[1, 2] * rhs.values[2, 3] + lhs.values[1, 3] * rhs.values[3, 3];

        //third row
        rValue.values[2, 0] = lhs.values[2, 0] * rhs.values[0, 0] + lhs.values[2, 1] * rhs.values[1, 0] + lhs.values[2, 2] * rhs.values[2, 0] + lhs.values[2, 3] * rhs.values[3, 0];
        rValue.values[2, 1] = lhs.values[2, 0] * rhs.values[0, 1] + lhs.values[2, 1] * rhs.values[1, 1] + lhs.values[2, 2] * rhs.values[2, 1] + lhs.values[2, 3] * rhs.values[3, 1];
        rValue.values[2, 2] = lhs.values[2, 0] * rhs.values[0, 2] + lhs.values[2, 1] * rhs.values[1, 2] + lhs.values[2, 2] * rhs.values[2, 2] + lhs.values[2, 3] * rhs.values[3, 2];
        rValue.values[2, 3] = lhs.values[2, 0] * rhs.values[0, 3] + lhs.values[2, 1] * rhs.values[1, 3] + lhs.values[2, 2] * rhs.values[2, 3] + lhs.values[2, 3] * rhs.values[3, 3];

        //fourth row
        rValue.values[3, 0] = lhs.values[3, 0] * rhs.values[0, 0] + lhs.values[3, 1] * rhs.values[1, 0] + lhs.values[3, 2] * rhs.values[2, 0] + lhs.values[3, 3] * rhs.values[3, 0];
        rValue.values[3, 1] = lhs.values[3, 0] * rhs.values[0, 1] + lhs.values[3, 1] * rhs.values[1, 1] + lhs.values[3, 2] * rhs.values[2, 1] + lhs.values[3, 3] * rhs.values[3, 1];
        rValue.values[3, 2] = lhs.values[3, 0] * rhs.values[0, 2] + lhs.values[3, 1] * rhs.values[1, 2] + lhs.values[3, 2] * rhs.values[2, 2] + lhs.values[3, 3] * rhs.values[3, 2];
        rValue.values[3, 3] = lhs.values[3, 0] * rhs.values[0, 3] + lhs.values[3, 1] * rhs.values[1, 3] + lhs.values[3, 2] * rhs.values[2, 3] + lhs.values[3, 3] * rhs.values[3, 3];

        return rValue;
    }
    //finish the rest of the inverse functions for rotation ans scale
    public Matrix4by4 TranslationInverse()
    {
        Matrix4by4 rValue = Identity;

        rValue.values[0, 3] = -values[0, 3];
        rValue.values[1, 3] = -values[1, 3];
        rValue.values[2, 3] = -values[2, 3];

        return rValue;
    }

    public Matrix4by4 RotationInverse()
    {
        Matrix4by4 rValue = Identity;

        return rValue;
    }

    public Matrix4by4 ScaleInverse()
    {
        Matrix4by4 rValue = Identity;

        return rValue;
    }
}
public class Quat
{
    public float w;
    public MyVector3 v;

    public Quat()
    {
        w = 0.0f;
        v = new MyVector3(0.0f, 0.0f, 0.0f);
    }
    public Quat(float angle, MyVector3 axis)
    {
        float halfAngle = angle / 2;
        w = Mathf.Cos(halfAngle);
        v = axis * Mathf.Sin(halfAngle);
    }

    public Quat(MyVector3 position)
    {
        w = 0.0f;
        v = new MyVector3(position.x, position.y, position.z);
    }
    public MyVector3 GetAxis()
    {
        MyVector3 rValue = new MyVector3(v.x, v.y, v.z);

        return rValue;
    }
    public void SetAxis(MyVector3 V)
    {
        v.x = V.x;
        v.y = V.y;
        v.z = V.z;
    }
    public static Quat operator *(Quat lhs, Quat rhs)
    {
        Quat rValue = new Quat();

        rValue.w = (rhs.w * lhs.w) - MyVector3.VectorDot(lhs.v, rhs.v);
        rValue.v = (lhs.v * rhs.w) + (rhs.v * lhs.w) + MathsLibrary.VectorCrossProduct(lhs.v, rhs.v);

        return rValue;
    }
    public Quat Inverse()
    {
        Quat rValue = new Quat();

        rValue.w = w;
        rValue.SetAxis(-GetAxis());

        return rValue;
    }
}
