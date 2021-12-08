using System;
using UnityEngine;

namespace UI.HealthBar {
    public class HealthBar : MonoBehaviour {
        private GameObject healthBarPrefab;

        private void Awake() {
            healthBarPrefab.SetActive(false);
        }

        private void OnMouseEnter() {
            healthBarPrefab.SetActive(true);
        }
        
        private void OnMouseExit() {
            healthBarPrefab.SetActive(false);
        }
    }
}