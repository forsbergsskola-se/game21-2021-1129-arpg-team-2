using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Game/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private float power;
    [SerializeField] private float range;
    [SerializeField] private bool ranged;
    [HideInInspector] [SerializeField] private GameObject projectile;
    
    public string Name
    {
        get => name;
        set => name = value;
    }

    public float Power
    {
        get => power;
        set => power = value;
    }

    public float Range
    {
        get => range;
        set => range = value;
    }

    public bool Ranged
    {
        get => ranged;
        set => ranged = value;
    }

    public GameObject Projectile
    {
        get => projectile;
        set => projectile = value;
    }
}
