using System;
using UnityEngine;

public enum ItemType
{
    None,
    Consumable,
    Weapon,
    Armour
}

[Serializable]
public abstract class BaseItem : ScriptableObject
{
    [Header("GameObject and sprite representations")]
    [SerializeField] private GameObject worldItemPrefab;
    [SerializeField] private Sprite inventoryItemIcon;
    public Sprite InventoryItemIcon { get => inventoryItemIcon; private set => inventoryItemIcon = value; }

    [Header("Width and height the item takes up in inventory UI")]
    [SerializeField] private int inventoryItemWidth;
    [SerializeField] private int inventoryItemHeight;
    public int InventoryItemWidth { get => inventoryItemWidth; private set => inventoryItemWidth = value; }
    public int InventoryItemHeight { get => inventoryItemHeight; private set => inventoryItemHeight = value; }

    [Header("Flavour text description")]
    [TextArea(15, 20)]
    [SerializeField] private string description;
    public string Description { get => description; private set => description = value; }
    
}
