using UnityEngine;

public abstract class ItemIS : ScriptableObject
{
    [Header("Item")]
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemIcon;
    public string ItemName => itemName;
    public Sprite ItemIcon => itemIcon;

    public abstract ItemIS GetItem();
    public abstract ConsumableIS GetConsumable();
}
