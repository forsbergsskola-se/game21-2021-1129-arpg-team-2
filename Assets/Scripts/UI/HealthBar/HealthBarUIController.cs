using UnityEngine;
using UnityEngine.UI;

public class HealthBarUIController : MonoBehaviour
{
   public Image healthBar;
   [SerializeField] private CharStats charStats;
   private Health health;
   private float previousFill;
   private float currentFill;
   private float fillSmoothness = 0.008f;
   
   private void Start()
   {
      if (charStats == null)
      {
         charStats = GetComponentInParent<Health>().CharStats;
      }
   }

   private void LateUpdate()
   {
      previousFill = healthBar.fillAmount;
      currentFill = charStats.CurrentHealth / charStats.MaxHealth;
   
      if (currentFill > previousFill)
      {
         previousFill = Mathf.Min(previousFill + fillSmoothness, currentFill);
      }
      else if (currentFill < previousFill)
      {
         previousFill = Mathf.Max(previousFill - fillSmoothness, currentFill);
      }
   
      healthBar.fillAmount = previousFill;
   }
}
