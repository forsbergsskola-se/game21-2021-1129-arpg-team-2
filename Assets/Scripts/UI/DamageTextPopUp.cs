using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI {
    public class DamageTextPopUp : MonoBehaviour{
        
        public GameObject floatingTextPrefab;

        public void ShowFlaotingText()
        {
            Debug.Log("ShowText has been called");
            var gameObject = Instantiate(floatingTextPrefab, this.transform);
            // gameObject.GetComponent<TextMeshPro>().text = currentHealth.ToString();
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