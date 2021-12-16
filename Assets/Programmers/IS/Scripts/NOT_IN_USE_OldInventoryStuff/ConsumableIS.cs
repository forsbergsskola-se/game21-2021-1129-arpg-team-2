using UnityEngine;

[CreateAssetMenu(fileName = "new consumable", menuName = "Item/Consumable")]
public class ConsumableIS : ItemIS
{
    [Header("Consumable")]
    [SerializeField] private ConsumableType consumableType;
    private enum ConsumableType
    {
        Meat,
        Apple
    }
    [SerializeField] private float healthAdded;

    public override ItemIS GetItem() => this;
    public override ConsumableIS GetConsumable() => this;
    public override EquippableIS GetEquippable() => null;
}
