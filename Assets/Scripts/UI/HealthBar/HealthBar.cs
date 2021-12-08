using System;
using UnityEngine;

namespace UI.HealthBar {
    public class HealthBar : MonoBehaviour {
        [NonSerialized] private GameObject healthBar;

        private void Awake() {
            healthBar = GameObject.Find("EnemyHealthBar");
            if (healthBar != null) {
                Debug.Log("Found hb");
            }
            healthBar.SetActive(false);
        }

        private void OnMouseEnter() {
            healthBar.SetActive(true);
        }
        
        private void OnMouseExit() {
            healthBar.SetActive(false);
        }
    }
}