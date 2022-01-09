using UnityEngine;

/// <summary>
/// Attach this to the Quest Log UI element in canvas
/// </summary>
public class QuestLogView : MonoBehaviour
{
    [SerializeField] private QuestLog playerQuestLog;
    [SerializeField] private GameObject questListView;
    [SerializeField] private GameObject questInspector;

    private QuestLog questLog;

    private void Awake()
    {
        playerQuestLog.NewQuestAdded.AddListener(OnNewQuestAdded);
    }
    
    private void OnNewQuestAdded(BaseQuest quest)
    {
        // var entry = Instantiate(questNamePrefab, questNamePrefab.transform.parent, false);
        // entry.GetComponent<QuestName>().Set(quest.QuestName);
        questListView.GetComponent<QuestListView>().AddNewQuestToListView(quest.QuestName);
        // questInspector.GetComponent<>()
    }
}
