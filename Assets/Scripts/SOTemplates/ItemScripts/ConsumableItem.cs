using UnityEngine;

[CreateAssetMenu(fileName = "new consumable", menuName = "Game/Inventory item/Consumable")]
public class ConsumableItem : BaseItem, IConsumable
{
    [SerializeField] private float buff;
    public float Buff => buff;
}

public enum ConsumableType
{
    Carrot,
    Potato,
    Potion
}
