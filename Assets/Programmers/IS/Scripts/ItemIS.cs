using UnityEngine;

public abstract class ItemIS : ScriptableObject
{
    [Header("Item")]
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemIcon;
    [SerializeField] private int size;
    public string ItemName => itemName;
    public Sprite ItemIcon => itemIcon;
    public int Size => size;

    public abstract ItemIS GetItem();
    public abstract ConsumableIS GetConsumable();
    public abstract EquippableIS GetEquippable();
}
