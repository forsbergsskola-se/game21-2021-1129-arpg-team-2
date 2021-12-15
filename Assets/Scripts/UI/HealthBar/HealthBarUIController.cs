using UnityEngine;
using UnityEngine.UI;

public class HealthBarUIController : MonoBehaviour
{
   public Image healthBar;
   [SerializeField] private CharStats charStats;
   private Health health;


   private void Awake()
   {
      if(charStats == null) charStats = GetComponentInParent<Health>().CharStats;
   }

   private void LateUpdate()
   {
      healthBar.fillAmount = charStats.CurrentHealth / charStats.MaxHealth;
   }
}
