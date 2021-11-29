using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityIS : MonoBehaviour, IDamageableIS
{
    [SerializeField] private EntityType entityType;
    [SerializeField] private FloatValue currentHealth;

    public FloatValue CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }

    public void TakeDamage(FloatValue damage)
    {
        CurrentHealth -= damage;
        Debug.Log("Entity is taking damage! " + CurrentHealth.Float);
    }
}
