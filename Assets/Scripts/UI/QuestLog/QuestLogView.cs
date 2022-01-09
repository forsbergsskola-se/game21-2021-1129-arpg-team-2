using UnityEngine;

/// <summary>
/// Attach this to the Quest Log UI element in canvas
/// </summary>
public class QuestLogView : MonoBehaviour
{
    [SerializeField] private QuestLog playerQuestLog;
    [SerializeField] private GameObject questListView;

    private QuestLog questLog;

    private void Awake()
    {
        playerQuestLog.NewQuestAdded.AddListener(OnNewQuestAdded);
    }
    
    private void OnNewQuestAdded(BaseQuest quest)
    {
        questListView.GetComponent<QuestListView>().AddNewQuestToListView(quest.QuestName);
    }
}
