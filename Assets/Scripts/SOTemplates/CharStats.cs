using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Game/CharStats", fileName = "CharStats")]
public class CharStats : ScriptableObject
{
    [Header("Stats")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float currenthealth;
    [SerializeField] private float attack;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float defence;

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

    public float Attack
    {
        get => attack;
        set => attack = value;
    }

    public float AttackSpeed
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }

    public float Defence
    {
        get => defence;
        set => defence = value;
    }
}
