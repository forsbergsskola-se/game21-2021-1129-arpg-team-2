using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyJO : MonoBehaviour, IDamageable
{
    [SerializeField] private FloatValue currentHealth;
    private float health;
    public FloatValue CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public void TakeDamage(FloatValue damage) {
        throw new NotImplementedException();
    }

    private void Start() {
        health = currentHealth.RuntimeValue;
        StartCoroutine(TestKill());
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        Debug.Log(health);
        
        if (health <= 0f)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator TestKill() {
        while (currentHealth.RuntimeValue > 0f) {
            TakeDamage(5f);
            yield return new WaitForSeconds(2);
        }
    }
}
