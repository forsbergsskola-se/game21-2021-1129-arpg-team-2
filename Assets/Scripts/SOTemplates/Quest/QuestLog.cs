using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "", menuName = "Game/Player/Quest log")]
public class QuestLog : ScriptableObject
{
    [SerializeField] private List<BaseQuest> activeQuestList;
    public List<BaseQuest> ActiveQuestList => activeQuestList;

    [HideInInspector] public UnityEvent<BaseQuest> NewQuestAdded;

    public void AddQuest(BaseQuest quest)
    {
        activeQuestList.Add(quest);
        quest.QuestStatus = QuestStatus.Active;
        NewQuestAdded.Invoke(quest);
    }
}
