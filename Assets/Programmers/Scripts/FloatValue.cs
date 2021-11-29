using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatValue", menuName = "Value/Float")]
public class FloatValue : ScriptableObject
{
    [SerializeField] private float floatValue;

    public float Float
    {
        get => floatValue;
        set => floatValue = value;
    }

    public FloatValue(float value)
    {
        floatValue = value;
    }

    public static FloatValue operator -(FloatValue a, FloatValue b)
    {
        var instance = CreateInstance<FloatValue>();
        instance.Float = a.Float - b.Float;
        return instance;
    }
    
    public static FloatValue operator +(FloatValue a, FloatValue b)
    {
        var instance = CreateInstance<FloatValue>();
        instance.Float = a.Float + b.Float;
        return instance;
    }
}
