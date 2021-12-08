using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEnemyHealthBar : MonoBehaviour
{
    private GameObject HealthBar;
    
    
    void Awake()
    {
        
        HealthBar = GameObject.FindWithTag("HealthBar");
        HealthBar.SetActive(false);
        
    }

    private void OnMouseEnter()
    {
        HealthBar.SetActive(true);
    }

    private void OnMouseExit()
    {
        HealthBar.SetActive(false);
    }
}
