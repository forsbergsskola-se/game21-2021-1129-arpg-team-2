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
            
            textMesh.text = (_health.CharStats.CurrentHealth - _previousHealth).ToString();
            _previousHealth = _health.CharStats.CurrentHealth;

        }
    }
}