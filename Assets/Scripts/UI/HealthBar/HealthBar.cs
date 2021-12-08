using System;
using UnityEngine;

namespace UI.HealthBar {
    public class HealthBar : MonoBehaviour {
        [SerializeField] private GameObject healthBar;
        private bool isInCombat;
        //getcomponent från enemy

        private void Awake() {
            healthBar.SetActive(false);
            PlayerAttack.OnPlayerEnteredCombat += InCombatChanged;
        }

        private void OnDestroy() {
            PlayerAttack.OnPlayerEnteredCombat -= InCombatChanged;
        }

        private void OnMouseEnter() {
            healthBar.SetActive(true);
        }
        
        private void OnMouseExit() {
            if (!isInCombat) {
                healthBar.SetActive(false);
            }
        }

        private void InCombatChanged(bool inCombat, IDamageable enemy)
        {
            
            healthBar.SetActive(inCombat);
            isInCombat = inCombat;
        }
    }
}