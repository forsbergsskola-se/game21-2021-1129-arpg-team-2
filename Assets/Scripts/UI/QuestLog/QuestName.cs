using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestName : MonoBehaviour
{
    [SerializeField] private QuestLog playerQuestLog;
    [SerializeField] private GameObject questDetail;

    private string activeQuestName;
    public void Set(string questName) => GetComponentInChildren<TextMeshProUGUI>().text = questName;

    private void SetQuestDetailView(List<QuestTodo> todoList) =>
        questDetail.GetComponent<QuestDetail>().Set(todoList);

    public void OnQuestNameClicked()
    {
        Debug.Log("A QuestName gameobject is being clicked");
        activeQuestName = GetComponentInChildren<TextMeshProUGUI>().text;
        var quest = playerQuestLog.ActiveQuestList.Find(x => x.QuestName == activeQuestName);

        Debug.Log("found quest: " + quest.QuestDescription);
        
        if (quest) SetQuestDetailView(quest.QuestTodoList); 
    }
}
