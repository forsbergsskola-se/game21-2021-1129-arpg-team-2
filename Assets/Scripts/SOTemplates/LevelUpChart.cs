using UnityEngine;

public class LevelUpChart : ScriptableObject
{
    [Header("Multiplicators")]
    [SerializeField] private float healthMultiplicator;
    [SerializeField] private float attackMultiplicator;
    [SerializeField] private float attackSpeedMultiplicator;
    [SerializeField] private float defenceMultiplicator;
    
    public float HealthMultiplicator => healthMultiplicator;
    public float AttackMultiplicator => attackMultiplicator;
    public float AttackSpeedMultiplicator => attackSpeedMultiplicator;
    public float DefenceMultiplicator => defenceMultiplicator;
    
    
}
