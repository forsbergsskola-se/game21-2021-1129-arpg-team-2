using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityIS : MonoBehaviour, IDamageableIS
{
    [SerializeField] private EntityType entityType;
    [SerializeField] private FloatValue currentHealth;
    public FloatValue CurrentHealth { get; set; }

    public void TakeDamage(IAttackIS attacker)
    {
        CurrentHealth.Float -= attacker.Power.Float;
    }
}
