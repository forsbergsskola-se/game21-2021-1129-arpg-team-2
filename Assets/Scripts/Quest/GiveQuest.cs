using UnityEngine;

public class GiveQuest : MonoBehaviour
{
    [SerializeField] private BaseQuest questToGive;
    [SerializeField] private QuestLog playerQuestLog;

    public void GiveQuestToPlayer()
    {
        playerQuestLog.AddQuest(questToGive);
    }
}
