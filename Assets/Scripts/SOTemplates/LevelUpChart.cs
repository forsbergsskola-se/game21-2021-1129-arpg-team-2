using UnityEngine;

public class LevelUpChart : ScriptableObject
{
    [Header("Multiplicators")]
    [SerializeField] private float healthMultiplicator;
    [SerializeField] private float experienceMultiplicator;
    [SerializeField] private float attackMultiplicator;
    [SerializeField] private float attackSpeedMultiplicator;
    [SerializeField] private float defenceMultiplicator;
}
