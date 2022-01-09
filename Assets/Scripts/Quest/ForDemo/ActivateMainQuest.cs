using System.Linq;
using TMPro;
using UnityEngine;

/// <summary>
/// This script is made for demo purpose.
/// Should be retired ASAP
/// </summary>
public class ActivateMainQuest : MonoBehaviour
{
    [SerializeField] private GameObject mainQuestQuickView;
    [SerializeField] private CollectQuest mainQuestFamilyMatters;
    [SerializeField] private GameObject questTitle;
    [SerializeField] private GameObject questTodos;

    private void Awake()
    {
        GetComponent<DialogueTrigger>().FamilyMattersActivated.AddListener(OnFamilyMattesActivated);
    }

    private void OnFamilyMattesActivated()
    {
        questTitle.GetComponent<TextMeshProUGUI>().text = mainQuestFamilyMatters.QuestName;
        questTodos.GetComponent<TextMeshProUGUI>().text = GetTodoText();
        mainQuestQuickView.SetActive(true);
    }

    private string GetTodoText() => mainQuestFamilyMatters.QuestTodoList.Aggregate("", (current, todo) => current + $"- {todo.Description} \n");
}
