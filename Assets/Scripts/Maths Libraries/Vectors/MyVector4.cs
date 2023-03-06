using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector4
{
    public float x, y, z, w;
    public MyVector4(float x, float y, float z, float w)
    {
        x = this.x;
        y = this.y;
        z = this.z;
        w = this.w;
    }
    public static MyVector4 addVector(MyVector4 a, MyVector4 b)
    {
        MyVector4 rValue = new MyVector4(0, 0, 0, 0);

        rValue.x = a.x + b.x;
        rValue.y = a.y + b.y;
        rValue.z = a.z + b.z;
        rValue.w = a.w + a.w;

        return rValue;
    }
    public static MyVector4 subVector(MyVector4 a, MyVector4 b)
    {
        MyVector4 rValue = new MyVector4(0, 0, 0, 0);

        rValue.x = a.x - b.x;
        rValue.y = a.y - b.y;
        rValue.z = a.z - b.z;
        rValue.w = a.w - a.w;

        return rValue;
    }
    public float Length()
    {
        float rValue = 0.0f;

        rValue = Mathf.Sqrt(x * x + y * y + z * z + w * w);

        return rValue;
    }
    public float LengthSquared()
    {
        float rValue = 0.0f;

        rValue = x * x + y * y + z * z + w * w;

        return rValue;
    }
    public static MyVector4 MultiplyVector(MyVector4 vector, float scalar)
    {
        MyVector4 rValue = new MyVector4(0, 0, 0, 0);

        rValue.x = vector.x * scalar;
        rValue.y = vector.y * scalar;
        rValue.z = vector.z * scalar;
        rValue.w = vector.w * scalar;

        return rValue;
    }
    public static MyVector4 DivideVector(MyVector4 vector, float divisor)
    {
        MyVector4 rValue = new MyVector4(0, 0, 0, 0);

        rValue.x = vector.x / divisor;
        rValue.y = vector.y / divisor;
        rValue.z = vector.z / divisor;
        rValue.w = vector.w / divisor;

        return rValue;
    }
    public static MyVector4 NormalizeVector(MyVector4 vector)
    {
        MyVector4 rValue = new MyVector4(0, 0, 0, 0);

        rValue = DivideVector(vector, vector.Length());

        return rValue;
    }
    public MyVector4 NormalizeVector()
    {
        MyVector4 rValue = new MyVector4(0, 0, 0, 0);

        rValue = DivideVector(this, this.Length());

        return rValue;
    }

    public static float VectorDot(MyVector4 a, MyVector4 b, bool ShouldNormalize = true)
    {
        float rValue = 0.0f;

        if (ShouldNormalize)
        {
            MyVector4 normA = a.NormalizeVector();
            MyVector4 normB = b.NormalizeVector();

            rValue = normA.x * normB.x + normA.y * normB.y + normA.z * normB.z + normA.w * normB.w;
        }
        else
        {
            rValue = a.x * b.x + a.y * b.y + a.z * b.z + a.w * a.w;
        }

        return rValue;
    }
    public Vector4 ToUnityVector()
    {
        Vector4 rValue = new Vector4(x, y, z, w);

        return rValue;
    }
}
    
