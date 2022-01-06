using System;
using UnityEngine;

/// <summary>
/// The struct is used to store dynamic data on individual InventoryItem instance
/// </summary>
[Serializable]
public struct ItemDataHolder
{
    private int width;
    private int height;
    private Sprite itemIcon;
    private ItemType type;
    private int? subType;

    public int Width => width;
    public int Height => height;
    public Sprite ItemIcon => itemIcon;
    public ItemType Type => type;
    public int? SubType => subType;

    public ItemDataHolder(BaseItem data)
    {
        width = data.InventoryItemWidth;
        height = data.InventoryItemHeight;
        itemIcon = data.InventoryItemIcon;
        type = data.ItemType;
        if (data.ItemType == ItemType.Consumable) subType = (int) data.ConsumableType;
        else subType = null;
    }
}
