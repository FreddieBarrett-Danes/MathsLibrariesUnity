using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector3
{
    public float x, y, z;
    public MyVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public static MyVector3 addVector(MyVector3 a, MyVector3 b)
    {
        MyVector3 rValue = new MyVector3(0, 0, 0);

        rValue.x = a.x + b.x;
        rValue.y = a.y + b.y;
        rValue.z = a.z + b.z;

        return rValue;
    }
    public static MyVector3 operator +(MyVector3 a, MyVector3 b)
    {
        return addVector(a, b);
    }
    public static MyVector3 subVector(MyVector3 a, MyVector3 b)
    {
        MyVector3 rValue = new MyVector3(0, 0, 0);

        rValue.x = a.x - b.x;
        rValue.y = a.y - b.y;
        rValue.z = a.z - b.z;

        return rValue;
    }
    public float Length()
    {
        float rValue = 0.0f;

        rValue = Mathf.Sqrt(x * x + y * y + z * z);

        return rValue;
    }
    public float LengthSquared()
    {
        float rValue = 0.0f;

        rValue = x * x + y * y + z * z;

        return rValue;
    }
    public static MyVector3 MultiplyVector(MyVector3 vector, float scalar)
    {
        MyVector3 rValue = new MyVector3(0, 0, 0);

        rValue.x = vector.x * scalar;
        rValue.y = vector.y * scalar;
        rValue.z = vector.z * scalar;

        return rValue;
    }
    public static MyVector3 DivideVector(MyVector3 vector, float divisor)
    {
        MyVector3 rValue = new MyVector3(0, 0, 0);

        rValue.x = vector.x / divisor;
        rValue.y = vector.y / divisor;
        rValue.z = vector.z / divisor;
       
        return rValue;
    }
    public static MyVector3 NormalizeVector(MyVector3 vector)
    {
        MyVector3 rValue = new MyVector3(0, 0, 0);

        rValue = DivideVector(vector, vector.Length());

        return rValue;
    }
    public MyVector3 NormalizeVector()
    {
        MyVector3 rValue = new MyVector3(0, 0, 0);

        rValue = DivideVector(this, this.Length());

        return rValue;
    }

    public static float VectorDot(MyVector3 a, MyVector3 b, bool ShouldNormalize = true)
    {
        float rValue = 0.0f;

        if (ShouldNormalize)
        {
            MyVector3 normA = a.NormalizeVector();
            MyVector3 normB = b.NormalizeVector();

            rValue = normA.x * normB.x + normA.y * normB.y + normA.z * normB.z;
        }
        else
        {
            rValue = a.x * b.x + a.y * b.y + a.z * b.z;
        }

        return rValue;
    }
    public Vector3 ToUnityVector()
    {
        Vector3 rValue = new Vector3(x, y, z);

        return rValue;
    }
    public static MyVector3 operator *(MyVector3 vector, float scalar)
    {
        return MultiplyVector(vector, scalar);
    }
    public static MyVector3 operator -(MyVector3 vector)
    {
        return new MyVector3(-vector.x,-vector.y, -vector.z);
    }
}
