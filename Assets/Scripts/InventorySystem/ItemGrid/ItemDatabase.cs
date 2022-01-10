using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Inventory database", menuName = "Game/Inventory/inventory database")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemData> itemDataList;

    public void AddItem(ItemData item)
    {
        Debug.Log($"Adding {item.Type} {item.SubType} to database...");
        itemDataList.Add(item);
    }

    public void RemoveItem(ItemData item)
    {
        Debug.Log($"Removing {item.Type} {item.SubType} to database...");
        itemDataList.Remove(item);
    }
    public void ClearItemDataList() => itemDataList.Clear();
}

[Serializable]
public struct ItemData
{
    [SerializeField] private int width;
    public int Width => width;
    
    [SerializeField] private int height;
    public int Height => height;
    
    [SerializeField] private Sprite itemIcon;
    public Sprite ItemIcon => itemIcon;
    
    [SerializeField] private ItemType type;
    public ItemType Type => type;
    
    [SerializeField] private int? subType;
    public int? SubType => subType;

    [SerializeField] private int onGridPositionX;
    public int OnGridPositionX { get => onGridPositionX; set => onGridPositionX = value; }
    
    [SerializeField] private int onGridPositionY;
    public int OnGridPositionY { get => onGridPositionY; set => onGridPositionY = value; }
    

    public ItemData(BaseItem item)
    {
        width = item.InventoryItemWidth;
        height = item.InventoryItemHeight;
        itemIcon = item.InventoryItemIcon;
        if (item is ConsumableItem c && c)
        {
            type = c.Type;
            subType = (int) c.SubType;
        }
        else if (item is WeaponItem w && w)
        {
            type = w.Type;
            subType = (int) w.SubType;
        }
        else if (item is QuestItem q && q)
        {
            type = q.Type;
            subType = (int) q.SubType;
        }
        else
        {
            type = ItemType.None;
            subType = null;
        }
        
        onGridPositionX = 0;
        onGridPositionY = 0;
    }
}
