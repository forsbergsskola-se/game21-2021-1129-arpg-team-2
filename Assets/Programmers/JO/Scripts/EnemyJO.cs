using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJO : MonoBehaviour, IDamageable
{
    [SerializeField] private FloatValue currentHealth;
    public FloatValue CurrentHealth { get => currentHealth; set => currentHealth = value; }
    
    public void TakeDamage(FloatValue damage)
    {
        CurrentHealth.RuntimeValue -= damage.RuntimeValue;
        
        if (CurrentHealth.RuntimeValue <= 0f)
        {
            Destroy(this);
        }
    }
}