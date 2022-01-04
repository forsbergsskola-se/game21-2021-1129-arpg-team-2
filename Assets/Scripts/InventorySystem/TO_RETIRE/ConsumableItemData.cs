using UnityEngine;

/// <summary>
/// Used to hold static values for items; not meant to be changed (most of the time, see comment for method ResetItemData())
/// </summary>

[CreateAssetMenu(fileName = "new consumable item", menuName = "Game/Inventory item/Consumable")]
public class ConsumableItemData : ScriptableObject
{
    [SerializeField] internal int width;
    [SerializeField] internal int height;
    [SerializeField] internal Sprite itemIcon;
    [SerializeField] internal ItemConsumable type;
    
    private bool hasValue;
    public bool HasValue { get => hasValue; set => hasValue = value; }

    // NOTE: Only use this when ItemData is used to pass dynamic values around
    public void ResetItemData()
    {
        width = 0;
        height = 0;
        itemIcon = null;
        HasValue = false;
        type = null;
    }
}
