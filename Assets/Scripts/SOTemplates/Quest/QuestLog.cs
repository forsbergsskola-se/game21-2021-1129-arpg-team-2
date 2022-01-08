using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Game/Player/Quest log")]
public class QuestLog : ScriptableObject
{
    [SerializeField] private List<BaseQuest> activeQuestList;
    public List<BaseQuest> ActiveQuestList => activeQuestList;

    public void InitQuestLog()
    {
        activeQuestList = new List<BaseQuest>();
    }

    public void AddQuest(BaseQuest quest) => activeQuestList.Add(quest);
}
