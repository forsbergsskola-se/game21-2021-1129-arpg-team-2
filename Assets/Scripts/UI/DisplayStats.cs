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
        string temp = $"Lvl: {playerLevelUpChart.CurrentLevel}  | Att: {this.playerStats.Attack:F2}  " +
                      $"| AttSp: {this.playerStats.AttackSpeed:F2} | Def: {playerStats.Defence:F2} ";
        
        _text.text = temp;
    }
}
