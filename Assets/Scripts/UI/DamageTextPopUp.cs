using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI {
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
            var temp = Instantiate(floatingTextPrefab, this.transform);
            temp.GetComponent<TextMeshPro>().text = (_health.CurrentHealth.RuntimeValue - _previousHealth).ToString();

            _previousHealth = _health.CurrentHealth.RuntimeValue;
        }
        
        
    }
    
    // private TextMeshPro textMesh;
    // private static Transform PrefabDamagePopup;
    //
    // public static DamagePopup Create(Vector3 position, int damageAmount)
    // {
    // Transform damagePopupTransform = Instantiate(PrefabDamagePopup, position, Quaternion.identity);
    // DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
    // damagePopup.Setup(300);
    // return damagePopup;
    // }
    //
    // private void Awake()
    // {
    // textMesh = transform.GetComponent<TextMeshPro>();
    // }
    //
    // public void Setup(int damageAmount)
    // {
    // textMesh.SetText(damageAmount.ToString());
    // }
}