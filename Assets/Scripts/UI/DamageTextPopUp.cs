using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DamageTextPopUp : MonoBehaviour{
        
        public GameObject floatingTextPrefab;
        private Health _health;

        private float _previousHealth;

        private void Start()
        {
            _health = GetComponent<Health>();
            _previousHealth = _health.CharStats.MaxHealth;
        }

        private void LateUpdate()
        {
            if(_previousHealth != _health.CharStats.CurrentHealth) ShowFlaotingText();
        }


        public void ShowFlaotingText()
        {
            var temp = Instantiate(floatingTextPrefab, transform);
            var textMesh = temp.GetComponentInChildren<TextMeshProUGUI>();

            float numberToDisplay = Mathf.Round(_health.CharStats.CurrentHealth - _previousHealth);
            textMesh.text = numberToDisplay.ToString();
            _previousHealth = _health.CharStats.CurrentHealth;

        }
    }
}