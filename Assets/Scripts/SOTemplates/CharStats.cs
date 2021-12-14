using UnityEngine;

[CreateAssetMenu(menuName = "Game/CharStats", fileName = "CharStats")]
public class CharStats : ScriptableObject
{
    [Header("Stats")]
    [SerializeField] private float health;
    [SerializeField] private float experience;
    [SerializeField] private float attack;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float defence;

    [Header("Dependencies")] 
    [SerializeField] private LevelUpChart _levelUpChart;

    public float Health => health;
    public float Experience => experience;
    public float Attack => attack;
    public float AttackSpeed => attackSpeed;
    public float Defence => defence;

    public void LevelUp()
    {
        if(HasLevelUpChart()) health *= _levelUpChart.HealthMultiplicator;
    }

    public void GainExperience(float xpUnity)
    {
        if(HasLevelUpChart()) experience += xpUnity;
    }

    private bool HasLevelUpChart()
    {
        return _levelUpChart != null;
    }
}
