using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new consumable", menuName = "Game/Inventory item/Consumable")]
public class ConsumableItem : BaseItem, IConsumable
{
    [SerializeField] private float buff;
    public float Buff => buff;
    
    private readonly ItemType type = ItemType.Consumable;
    public ItemType Type => type;
    
    [SerializeField] private ConsumableType subType;
    public ConsumableType SubType => subType;
    
    [SerializeField] private bool isPerishable;
    public bool IsPerishable => isPerishable;
    
    [SerializeField] private float expirationInSeconds;
    public float ExpirationInSeconds => expirationInSeconds;
}

[Serializable]
public enum ConsumableType
{
    Carrot,
    Potato,
    Potion
}
