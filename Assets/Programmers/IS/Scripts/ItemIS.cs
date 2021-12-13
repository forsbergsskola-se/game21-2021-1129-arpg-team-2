using UnityEngine;

public abstract class ItemIS : ScriptableObject
{
    [Header("Item")]
    [SerializeField] private string itemName;
    public string ItemName => itemName;

    public abstract ItemIS GetItem();
    public abstract ConsumableIS GetConsumable();
}
