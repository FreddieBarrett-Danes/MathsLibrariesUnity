using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector2
{
    public float x, y;
    public MyVector2(float x, float y)
    {
        x = this.x;
        y = this.y;
    }
    public static MyVector2 addVector(MyVector2 a, MyVector2 b)
    {
        MyVector2 rValue = new MyVector2(0, 0);

        rValue.x = a.x + b.x;
        rValue.y = a.y + b.y;

        return rValue;
    }
    public static MyVector2 subVector(MyVector2 a, MyVector2 b)
    {
        MyVector2 rValue = new MyVector2(0, 0);

        rValue.x = a.x - b.x;
        rValue.y = a.y - b.y;

        return rValue;
    }
    public float Length()
    {
        float rValue = 0.0f;

        rValue = Mathf.Sqrt(x * x + y * y);

        return rValue;
    }
    public float LengthSquared()
    {
        float rValue = 0.0f;

        rValue = x * x + y * y;

        return rValue;
    }
    public static MyVector2 MultiplyVector(MyVector2 vector, float scalar)
    {
        MyVector2 rValue = new MyVector2(0, 0);

        rValue.x = vector.x * scalar;
        rValue.y = vector.y * scalar;

        return rValue;
    }
    public static MyVector2 DivideVector(MyVector2 vector, float divisor)
    {
        MyVector2 rValue = new MyVector2(0, 0);

        rValue.x = vector.x / divisor;
        rValue.y = vector.y / divisor;

        return rValue;
    }
    public static MyVector2 NormalizeVector(MyVector2 vector)
    {
        MyVector2 rValue = new MyVector2(0, 0);

        rValue = DivideVector(vector, vector.Length());

        return rValue;
    }
    public MyVector2 NormalizeVector()
    {
        MyVector2 rValue = new MyVector2(0, 0);

        rValue = DivideVector(this, this.Length());

        return rValue;
    }

    public static float VectorDot(MyVector2 a, MyVector2 b, bool ShouldNormalize = true)
    {
        float rValue = 0.0f;

        if (ShouldNormalize)
        {
            MyVector2 normA = a.NormalizeVector();
            MyVector2 normB = b.NormalizeVector();

            rValue = normA.x * normB.x + normA.y * normB.y;
        }
        else
        {
            rValue = a.x * b.x + a.y * b.y;
        }

        return rValue;
    }
    public Vector2 ToUnityVector()
    {
        Vector2 rValue = new Vector2(x, y);

        return rValue;
    }
}
