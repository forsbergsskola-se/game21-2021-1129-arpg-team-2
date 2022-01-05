using UnityEngine;

[CreateAssetMenu(fileName = "new weapon item", menuName = "Game/Inventory item/Weapon")]
public class WeaponItem : BaseItem // IEquippable should be implemented here
{
    [SerializeField] private float buff;
    public float Buff => buff;
}

public enum WeaponType
{
    Fire,
    Ice,
    Light
}
