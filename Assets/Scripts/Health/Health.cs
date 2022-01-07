using UnityEngine;
using System;
using System.Collections;
using Unity.Mathematics;

public class Health : MonoBehaviour, IDamageable, IConsumer {
    public Action<float> OnTakeDamage;
    [SerializeField] private CharStats charStats;
    [SerializeField] private float maxHealth;

    public GameEvent entityDeath;
    public GameEventListener deathListner;
    [SerializeField] private FloatValue currentHealth;

    public CharStats CharStats
    {
        get => charStats;
        set => charStats = value;
    }

    public FloatValue CurrentHealth
    {
        get => currentHealth; 
        set => currentHealth = value;
    }

    private HealEffect healEffect;
    
    private void Awake()
    {
        if (charStats == null)
        {
            charStats = ScriptableObject.CreateInstance<CharStats>();
            charStats.CurrentHealth = maxHealth;
            charStats.MaxHealth = maxHealth;
        }
        else charStats.CurrentHealth = charStats.MaxHealth;

        if (entityDeath == null)
        {
            entityDeath = ScriptableObject.CreateInstance<GameEvent>();
            deathListner.Event = entityDeath;
        }

        healEffect = GetComponent<HealEffect>();
    }
    
    public void TakeDamage(float damage)
    {
        var totalDamage = damage - charStats.Defence;
        charStats.CurrentHealth -= totalDamage;

        if (charStats.CurrentHealth <= 0f) entityDeath.Raise();
        
        OnTakeDamage?.Invoke(damage);
    }

    public void ResetHealth() 
    {
        charStats.CurrentHealth = charStats.MaxHealth;
    }
    
    public void Consume(IConsumable consumable)
    {
        charStats.CurrentHealth += consumable.Buff;
        healEffect.PlayEffect();
    }
}


