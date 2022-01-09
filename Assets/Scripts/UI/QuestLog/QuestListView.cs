using UnityEngine;

public class QuestListView : MonoBehaviour
{
    [SerializeField] private GameObject questNamePrefab;
    [SerializeField] private QuestLog playerQuestLog;
    
    // private void Awake()
    // {
    //     playerQuestLog.NewQuestAdded.AddListener(OnNewQuestAdded);
    // }

    private void Start()
    {
        // Populate quest list for pre-existing quest(s) from PlayerQuestLog
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

    // Add quest whenever GiveQuest script is fired
    public void AddNewQuestToListView(string questName)
    {
        var entry = Instantiate(questNamePrefab, questNamePrefab.transform.parent, false);
        entry.GetComponent<QuestName>().Set(questName);
    }
}
