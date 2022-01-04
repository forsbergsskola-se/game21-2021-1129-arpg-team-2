using System;
using UnityEngine;

/// <summary>
/// The class is used to store dynamic data on individual InventoryItem instance
/// </summary>
[Serializable]
public class ItemClass
{
    private int width;
    private int height;
    private Sprite itemIcon;
    private ItemConsumable.ConsumableType type;

    public int Width => width;
    public int Height => height;
    public Sprite ItemIcon => itemIcon;
    public ItemConsumable.ConsumableType Type => type;

    public ItemClass(ConsumableItemData data)
    {
        width = data.width;
        height = data.height;
        itemIcon = data.itemIcon;
        type = data.type.Type;
    }
}
