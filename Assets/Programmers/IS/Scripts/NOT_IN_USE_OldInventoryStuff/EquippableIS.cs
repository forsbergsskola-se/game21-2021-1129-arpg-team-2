using UnityEngine;

[CreateAssetMenu(fileName = "new equippable", menuName = "Item/Equippable")]
public class EquippableIS : ItemIS
{
    [Header("Equippable")]
    [SerializeField] private EquippableType equippableType;

    private enum EquippableType
    {
        Weapon,
        Armour
    }

    [SerializeField] private float ampAdded;
    public override ItemIS GetItem() => this;
    public override ConsumableIS GetConsumable() => null;
    public override EquippableIS GetEquippable() => this;
}
