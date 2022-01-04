using UnityEngine;

[CreateAssetMenu(fileName = "new consumable", menuName = "Game/Inventory item/Consumable")]
public class ConsumableItem : BaseItem
{
    [SerializeField] private float buff;
}
