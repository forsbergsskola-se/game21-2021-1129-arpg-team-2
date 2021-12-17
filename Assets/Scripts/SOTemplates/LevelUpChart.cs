using UnityEngine;

[CreateAssetMenu(menuName = "Game/LevelUpChart", fileName = "LevelUpChart")]
public class LevelUpChart : ScriptableObject
{
    [Header("Level")] 
    [SerializeField] private int currentLevel;
    [SerializeField] private int currentXp;
    [SerializeField] private float[] xpMilestones;

    public int CurrentLevel => currentLevel;
    public int CurrentXp => currentXp;
    private float[] XpMilestones => xpMilestones;
    
    
    [Header("Multiplicators")]
    [SerializeField] private float health;
    [SerializeField] private float attack;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float defence;
    
    public float HealthMultiplicator => health;
    public float AttackMultiplicator => attack;
    public float AttackSpeedMultiplicator => attackSpeed;
    public float DefenceMultiplicator => defence;

    public void Reset()
    {
        currentLevel = 1;
        currentXp = 0;
    }
    
    
}
