using System;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private CharStats charStats;
    [SerializeField] private LevelUpChart levelUpChart;
    [SerializeField] private GameEvent levelUp;

    private void Awake()
    {
        charStats.Reset();
        levelUpChart.Reset();
    }

    public void GainXp(int xp)
    {
        levelUpChart.CurrentXp += xp;
        
        if(ReachedXpMilestone()) LevelUp();
    }

    private bool ReachedXpMilestone()
    {
        var index = levelUpChart.CurrentLevel;
        
        return levelUpChart.CurrentXp > levelUpChart.XpMilestones[index];
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
