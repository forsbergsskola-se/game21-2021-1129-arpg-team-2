using UnityEngine;

[CreateAssetMenu(fileName = "new collect quest", menuName = "Game/Quest/Collect quest")]
public class CollectQuest : BaseQuest
{
    private readonly SubQuestType subQuestType = SubQuestType.Collect;
    public SubQuestType SubQuestType => subQuestType;

    [SerializeField] private QuestType questType;
    public QuestType QuestType => questType;
}
