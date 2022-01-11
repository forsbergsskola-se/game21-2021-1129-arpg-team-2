using UnityEngine;

/// <summary>
/// This script is made for demo purpose.
/// Should be retired ASAP
/// </summary>
public class ActivateMainQuest : MonoBehaviour
{
    [SerializeField] private GameObject mainQuestQuickView;
    [SerializeField] private GameObject logQuestName;
    [SerializeField] private GameObject logQuestDetail;

    private void Awake()
    {
        GetComponent<DialogueTrigger>().FamilyMattersActivated.AddListener(OnFamilyMattesActivated);
    }

    private void OnFamilyMattesActivated()
    {
        mainQuestQuickView.SetActive(true);
        logQuestName.SetActive(true);
        logQuestDetail.SetActive(true);
    }
}
