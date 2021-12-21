using System;
using UnityEngine;

/// <summary>
/// The class is used to store dynamic data on individual InventoryItem instance
/// </summary>
[Serializable]
public class ItemClassIS
{
    private int width;
    private int height;
    private Sprite itemIcon;

    public int Width => width;
    public int Height => height;
    public Sprite ItemIcon => itemIcon;

    public ItemClassIS(int width, int height, Sprite itemIcon)
    {
        this.width = width;
        this.height = height;
        this.itemIcon = itemIcon;
    }
}
