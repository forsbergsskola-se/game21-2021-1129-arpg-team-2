using UnityEngine;

[CreateAssetMenu(fileName = "new consumable", menuName = "Game/Inventory item/Consumable")]
public class ConsumableItem : BaseItem, IConsumable
{
    [SerializeField] private float buff;
    public float Buff => buff;
    
    // [SerializeField] private ConsumableType subType;
    // public ConsumableType SubType => subType;
}

public enum ConsumableType
{
    Carrot,
    Potato,
    Potion
}
