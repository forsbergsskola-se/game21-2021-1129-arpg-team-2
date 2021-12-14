using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUIController : MonoBehaviour
{
   public Image healthBar;
   public Health health;

   
   private void LateUpdate()
   {
      healthBar.fillAmount = health.CurrentHealth.RuntimeValue / health.CurrentHealth.InitialValue;
   }
   
}
