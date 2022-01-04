using UnityEngine;

public enum ItemType
{
    Consumable,
    Weapon,
    Armour
    // ,Special e.g. special items for completing quests
}

public abstract class BaseItem : ScriptableObject
{
    [Header("GameObject and sprite representations")]
    [SerializeField] private GameObject worldItemPrefab;
    [SerializeField] private Sprite inventoryItemIcon;
    
    [Header("Width and height the item takes up in inventory UI")]
    [SerializeField] private int inventoryItemWidth;
    [SerializeField] private int inventoryItemHeight;

    [SerializeField] private ItemType itemType;
    
    [Header("Flavour text description")]
    [TextArea(15, 20)]
    [SerializeField] private string description;
}
