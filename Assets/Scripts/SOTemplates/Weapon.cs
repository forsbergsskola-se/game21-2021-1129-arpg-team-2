using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Game/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private float power;
    [SerializeField] private float range;
    public float Power => power;
    public float Range => range;
    public string Name => name;
}
