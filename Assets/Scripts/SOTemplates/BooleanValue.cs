using UnityEngine;

[CreateAssetMenu(fileName = "BooleanValue", menuName = "Value/Boolean")]
public class BooleanValue : ScriptableObject
{
    [SerializeField] private bool boolValue;
    public bool BoolValue { get => boolValue; set => boolValue = value; }
}
