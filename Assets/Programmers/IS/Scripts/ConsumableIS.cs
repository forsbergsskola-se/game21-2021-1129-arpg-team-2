using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new consumable", menuName = "Item/Consumable")]
public class ConsumableIS : ItemIS
{
    [Header("Consumable")]
    [SerializeField] private ConsumableType consumableType;
    public enum ConsumableType
    {
        HealthPotion,
        Mushroom
    }
    [SerializeField] private float healthAdded;

    public override ItemIS GetItem() => this;
    public override ConsumableIS GetConsumable() => this;
}
