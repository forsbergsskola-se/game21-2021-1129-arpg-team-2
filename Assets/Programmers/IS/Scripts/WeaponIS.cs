using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Game/Weapon")]
public class WeaponIS : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private float power;
    [SerializeField] private FloatValue range;
    public float Power => power;
    public float Range => range.RuntimeValue;
    public string Name => name;
}
