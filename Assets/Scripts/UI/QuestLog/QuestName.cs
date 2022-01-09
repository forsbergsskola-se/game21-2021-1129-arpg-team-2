using TMPro;
using UnityEngine;

public class QuestName : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    public void Set(string questName) => textMeshProUGUI.text = questName;
}
