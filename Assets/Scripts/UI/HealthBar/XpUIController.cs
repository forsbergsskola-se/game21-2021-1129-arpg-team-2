using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class XpUIController : MonoBehaviour
{
   [SerializeField] private Image xpBar;
   [SerializeField] private LevelUpChart levelUpChart;
   private float previousFill;
   private float currentFill;
   private float fillSmoothness = 0.008f;

   private void LateUpdate()
   {
      previousFill = xpBar.fillAmount;

      currentFill = NormilizeXp();
      
      // Debug.Log(currentFill);

      if (currentFill > previousFill)
      {
         previousFill = Mathf.Min(previousFill + fillSmoothness, currentFill);
      }
      else if (currentFill < previousFill)
      {
         previousFill = Mathf.Max(previousFill - fillSmoothness, currentFill);
      }
   
      xpBar.fillAmount = previousFill;
   }

   private float NormilizeXp()
   {
      return (levelUpChart.CurrentXp - levelUpChart.XpMilestones[levelUpChart.CurrentLevel - 1])/ 
             (levelUpChart.XpMilestones[levelUpChart.CurrentLevel] - levelUpChart.XpMilestones[levelUpChart.CurrentLevel - 1]);
   }
}
