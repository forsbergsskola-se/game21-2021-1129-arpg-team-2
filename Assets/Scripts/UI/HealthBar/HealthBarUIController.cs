using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUIController : MonoBehaviour
{
   public Image healthBar;
   private Health health;


   private void Awake()
   {
      health = GetComponentInParent<Health>();
   }

   private void LateUpdate()
   {
      healthBar.fillAmount = health.CharStats.CurrentHealth / health.CharStats.MaxHealth;
   }
}
