using TMPro;
using UnityEngine;

namespace UI {
    public class DamageTextPopUp : MonoBehaviour{
        public GameObject FloatingTextPrefab;

        void ShowFlaotingText()
        {
            var gameObject = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
            //gameObject.GetComponent<TextMeshPro>().text = currentHealth.ToString();
        }
    }
}