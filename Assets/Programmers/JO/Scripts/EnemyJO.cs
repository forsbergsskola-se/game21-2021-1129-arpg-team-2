using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyJO : MonoBehaviour
{
    [SerializeField] private FloatValue currentHealth;
    private float health;
    public FloatValue CurrentHealth { get => currentHealth; set => currentHealth = value; }

    private void Start() {
        health = currentHealth.RuntimeValue;
        StartCoroutine(TestKill());
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Takedam method");
        health -= damage;
        
        Debug.Log(health);
        
        if (health <= 0f)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator TestKill() {
        Debug.Log("testkill method");

        while (currentHealth.RuntimeValue > 0f) {
            TakeDamage(5f);
            yield return new WaitForSeconds(2);
        }
    }
}
