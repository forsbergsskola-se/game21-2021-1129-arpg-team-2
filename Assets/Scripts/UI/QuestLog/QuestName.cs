using TMPro;
using UnityEngine;

public class QuestName : MonoBehaviour
{
    public void Set(string questName) => GetComponent<TextMeshProUGUI>().text = questName;
}
