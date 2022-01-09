using System;
using UnityEngine;

public class QuestListControl : MonoBehaviour
{
    [SerializeField] private GameObject questNamePrefab;
    [SerializeField] private QuestLog playerQuestLog;

    private void Start()
    {
        Debug.Log("Start from QuestListControl fires");
        if (playerQuestLog.ActiveQuestList.Count != 0) PopulateWithActiveQuests();
    }

    private void PopulateWithActiveQuests()
    {
        foreach (var quest in playerQuestLog.ActiveQuestList)
        {
            var entry = Instantiate(questNamePrefab, questNamePrefab.transform.parent, false);
            entry.GetComponent<QuestName>().Set(quest.QuestName);
        }
    }
}
