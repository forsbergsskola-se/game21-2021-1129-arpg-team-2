using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Game/CharStats", fileName = "CharStats")]
public class CharStats : ScriptableObject
{
    [Header("Initial Stats")]
    [SerializeField] private float maxHealthInitial;
    [SerializeField] private float attackInitial;
    [SerializeField] private float attackSpeedInitial;
    [SerializeField] private float defenceInitial;

    [Header("Current Stats")]
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

    public void Reset()
    {
        maxHealth = maxHealthInitial;
        currenthealth = maxHealthInitial;
        attack = attackInitial;
        attackSpeed = attackSpeedInitial;
        defence = defenceInitial;
    }
}
