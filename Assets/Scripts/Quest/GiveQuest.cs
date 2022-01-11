// using UnityEngine;
//
// public class GiveQuest : MonoBehaviour
// {
//     [SerializeField] private BaseQuest questToGive;
//     [SerializeField] private QuestLog playerQuestLog;
//
//     private DialogueTrigger dialogueTrigger;
//
//     private void Awake()
//     {
//         dialogueTrigger = GetComponent<DialogueTrigger>();
//         dialogueTrigger.QuestGiverFires.AddListener(GiveQuestToPlayer);
//     }
//
//     public void GiveQuestToPlayer()
//     {
//         if (IsQuestFresh()) playerQuestLog.AddQuest(questToGive);
//     }
//
//     private bool IsQuestFresh()
//     {
//         var isInQuestLog = playerQuestLog.ActiveQuestList.Find(x => x.QuestName == questToGive.QuestName);
//         return !isInQuestLog;
//     }
// }
