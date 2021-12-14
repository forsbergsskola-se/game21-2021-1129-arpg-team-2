using UnityEngine;

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
        health *= _levelUpChart.HealthMultiplicator;
    }

    public void GainExperience(float xpUnity)
    {
        experience += xpUnity;
    }
}
