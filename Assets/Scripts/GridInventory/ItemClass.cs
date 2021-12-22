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
    private int? worldItemId;

    public int Width => width;
    public int Height => height;
    public Sprite ItemIcon => itemIcon;
    public int? WorldItemId => worldItemId;

    public ItemClass(int width, int height, Sprite itemIcon, int? worldItemId)
    {
        this.width = width;
        this.height = height;
        this.itemIcon = itemIcon;
        this.worldItemId = worldItemId;
    }
}
