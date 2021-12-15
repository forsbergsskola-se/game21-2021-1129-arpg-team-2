using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Game/CharStats", fileName = "CharStats")]
public class CharStats : ScriptableObject
{
    [Header("Stats")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float currenthealth;
    [SerializeField] private float experience;
    [SerializeField] private float attack;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float defence;

    [Header("Dependencies")] 
    [SerializeField] private LevelUpChart levelUpChart;

    public float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    public float CurrentHealth
    {
        get => currenthealth;
        set => currenthealth = value;
    }

    public float Experience => experience;
    public float Attack => attack;
    public float AttackSpeed => attackSpeed;
    public float Defence => defence;

    public void LevelUp()
    {
        if(HasLevelUpChart()) currenthealth *= levelUpChart.HealthMultiplicator;
    }

    public void GainExperience(float xpUnity)
    {
        if(HasLevelUpChart()) experience += xpUnity;
    }

    private bool HasLevelUpChart()
    {
        return levelUpChart != null;
    }
}
