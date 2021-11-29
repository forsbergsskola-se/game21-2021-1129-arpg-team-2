using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatVar", menuName = "Value/FloatVar")]
public class FloatVariableIS : ScriptableObject, ISerializationCallbackReceiver
{
    public float InitialValue;

    [NonSerialized]
    public float RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize() { }
}
