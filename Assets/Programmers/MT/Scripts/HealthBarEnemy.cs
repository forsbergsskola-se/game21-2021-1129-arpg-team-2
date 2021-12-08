using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    private Health health;
    public GameObject FloatingTextPrefab;
    private float PreviousHealth;
    void Awake()
    {
        PreviousHealth = health.CurrentHealth.InitialValue;

    }

    private void Update()
    {
        if (PreviousHealth != health.CurrentHealth.RuntimeValue)
        {
            if (FloatingTextPrefab != null)
            {
                ShowFlaotingText();
            }
        }
    }

    void OnMouseEnter()
    {
        GameObject.FindWithTag("HealthBar").SetActive(true);
        
    }
    
    void OnMouseExit()
    {
        GameObject.FindWithTag("HealthBar").SetActive(false);
    }
   
    
    void ShowFlaotingText()
    {
        Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
    }
}
