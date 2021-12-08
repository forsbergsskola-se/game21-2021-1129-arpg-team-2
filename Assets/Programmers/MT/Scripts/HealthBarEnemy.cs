using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour, IDamageable
{
    private Health health;
    // public GameObject FloatingTextPrefab;
    private float previousHealth;
    [SerializeField] private GameObject healthBar;
    void Awake()
    {
        previousHealth = health.CurrentHealth.InitialValue;
        healthBar.SetActive(false);
        

    }

    

    public FloatValue CurrentHealth { get; set; }

    public void TakeDamage(float damage)
    {
        // FlashRed();
        // healthealth.RuntimeValue -= damage;

        // Debug.Log("entityDeath event: " + entityDeath);
        
        // if (CurrentHealth.RuntimeValue <= 0f) entityDeath.Raise();
        // Debug.Log(this.gameObject + ": " + CurrentHealth);
        
        
        // if (FloatingTextPrefab)
        // {
        //     ShowFlaotingText();
        // }
        
    }

    void OnMouseEnter()
    {
        
        healthBar.SetActive(true);
        
    }
    
    void OnMouseExit()
    {
        healthBar.SetActive(false);
    }
   
    
    // void ShowFlaotingText()
    // {
    //     Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
    // }
}
