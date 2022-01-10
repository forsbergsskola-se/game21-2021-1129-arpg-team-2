using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class DisplayStats : MonoBehaviour
{
    [SerializeField] private CharStats playerStats;
    [SerializeField] private LevelUpChart playerLevelUpChart;
    private TextMeshProUGUI _text;

    private void Awake() => _text = GetComponent<TextMeshProUGUI>();
    
    private void LateUpdate() => ShowStats();
    
    private void ShowStats()
    {
        _text.text = "Lvl: " + Mathf.Round(playerLevelUpChart.CurrentLevel) + " | Att: " + string.Format(playerStats.Attack):0.00 + " | AttSp: "
                     + Mathf.Round(playerStats.AttackSpeed) + " | Def: " + Mathf.Round(playerStats.Defence);
    }
}
