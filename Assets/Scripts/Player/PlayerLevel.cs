using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private CharStats charStats;
    [SerializeField] private LevelUpChart levelUpChart;
    [SerializeField] private GameEvent levelUp;

    public void GainXp(int xp)
    {
        levelUpChart.CurrentXp += xp;
        
        if(ReachedXpMilestone()) LevelUp();
    }

    private bool ReachedXpMilestone()
    {
        return levelUpChart.CurrentXp > levelUpChart.XpMilestones[levelUpChart.CurrentLevel - 1];
    }

    private void LevelUp()
    {
        charStats.MaxHealth *= levelUpChart.HealthMultiplicator;
        charStats.CurrentHealth = charStats.MaxHealth;

        charStats.Attack *= levelUpChart.AttackMultiplicator;
        charStats.AttackSpeed *= levelUpChart.AttackSpeedMultiplicator;
        charStats.Defence *= levelUpChart.DefenceMultiplicator;

        levelUpChart.CurrentLevel++;
        
        levelUp.Raise();
    }
}
