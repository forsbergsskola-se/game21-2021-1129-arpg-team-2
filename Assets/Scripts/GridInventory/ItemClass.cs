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
    private ItemData data;

    public int Width => width;
    public int Height => height;
    public Sprite ItemIcon => itemIcon;
    public ItemData Data => data;

    public ItemClass(ItemData data)
    {
        this.data = data;
        width = data.width;
        height = data.height;
        itemIcon = data.itemIcon;
    }
}
