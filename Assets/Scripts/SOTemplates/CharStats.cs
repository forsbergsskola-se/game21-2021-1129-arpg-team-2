using UnityEngine;

public class CharStats : ScriptableObject
{
    [SerializeField] private float health;
    [SerializeField] private float experience;
    [SerializeField] private float attack;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float defence;

    public float Health => health;
    public float Experience => experience;
    public float Attack => attack;
    public float AttackSpeed => attackSpeed;
    public float Defence => defence;

    public void LevelUp()
    {
        
    }
}
