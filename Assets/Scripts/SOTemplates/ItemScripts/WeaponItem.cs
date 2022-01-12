using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new weapon item", menuName = "Game/Inventory item/Weapon")]
public class WeaponItem : BaseItem // IEquippable should be implemented here
{
    [SerializeField] private float buff;
    public float Buff => buff;

    private readonly ItemType type = ItemType.Weapon;
    public ItemType Type => type;

    [SerializeField] private WeaponType subType;
    public WeaponType SubType => subType;
}

[Serializable]
public enum WeaponType
{
    Fire,
    Ice,
    Light
}
