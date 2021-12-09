using System;
using UnityEngine;

namespace UI.HealthBar {
    public class HealthBar : MonoBehaviour {
        [SerializeField] private GameObject healthBar;
        private bool isInCombat;
        private Enemy enemy;

        private void Awake() {
            enemy = GetComponent<Enemy>();
            healthBar.SetActive(false);
            enemy.InCombatChanged += InCombatChanged;
        }

        private void OnDestroy() {
            enemy.InCombatChanged -= InCombatChanged;
        }

        private void OnMouseEnter() {
            healthBar.SetActive(true);
        }
        
        private void OnMouseExit() {
            if (!isInCombat) {
                healthBar.SetActive(false);
            }
        }

        private void InCombatChanged(bool inCombat)
        {
            healthBar.SetActive(inCombat);
            isInCombat = inCombat;
        }
    }
}