using UnityEngine;

public class PlayerAttackIS : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // The range for this trigger is controller by SphereCollider/Radius
        if (other.TryGetComponent(out EntityIS entity) && entity is IDamageableIS)
        {
            Debug.Log("An IDamageable entity in range!");
        }
    }
}
