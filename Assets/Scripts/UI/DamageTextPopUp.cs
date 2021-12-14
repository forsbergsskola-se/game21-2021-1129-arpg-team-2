using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(Health))]
    public class DamageTextPopUp : MonoBehaviour{
        
        public GameObject floatingTextPrefab;
        private Health _health;

        private float _previousHealth;

        private void Start()
        {
            _health = GetComponent<Health>();
            _previousHealth = _health.CurrentHealth.InitialValue;
        }


        public void ShowFlaotingText()
        {
            Debug.Log("Current Health: " + _health.CurrentHealth.RuntimeValue);
            Debug.Log("Previous Health: " + _previousHealth);
            var temp = Instantiate(floatingTextPrefab, transform);
            temp.GetComponentInChildren<TextMeshProUGUI>().text = (_health.CurrentHealth.RuntimeValue - _previousHealth).ToString();
            _previousHealth = _health.CurrentHealth.RuntimeValue;
        }
    }
}