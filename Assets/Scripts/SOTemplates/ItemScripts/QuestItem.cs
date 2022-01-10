using UnityEngine;

[CreateAssetMenu(fileName = "new quest item", menuName = "Game/Inventory item/Quest item")]
public class QuestItem : BaseItem
{
    private readonly ItemType type = ItemType.Consumable;
    public ItemType Type => type;
    [SerializeField] private QuestItemType subQuestType;
    public QuestItemType SubType => subQuestType;
}

public enum QuestItemType
{
    RoyalBlood,
    RareFlower,
    Bone
}
