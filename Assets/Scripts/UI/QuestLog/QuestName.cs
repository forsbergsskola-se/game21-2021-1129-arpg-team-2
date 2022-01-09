using TMPro;
using UnityEngine;

public class QuestName : MonoBehaviour
{
    private string activeQuestName;

    public void Set(string questName)
    {
        GetComponent<TextMeshProUGUI>().text = questName;
        activeQuestName = questName;
    }

    public void ShowQuestTodoList()
    {
        
    }
}
