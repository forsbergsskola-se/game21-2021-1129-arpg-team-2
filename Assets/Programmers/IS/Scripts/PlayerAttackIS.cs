using System.Collections;
using UnityEngine;

public class PlayerAttackIS : MonoBehaviour, IAttackIS
{
    [SerializeField] private FloatValue power;
    [SerializeField] private FloatValue attackInterval;

    public FloatValue Power
    {
        get => power;
        set => power = value;
    }

    public void Attack(IDamageableIS thisTarget)
    {
        Debug.Log("Show me Power: " + Power);
        Debug.Log("Show me Power.Float: " + Power.Float);
        thisTarget.TakeDamage(Power);
    }

    private IEnumerator AttackOnInterval(IDamageableIS entity)
    {
        Attack(entity);
        yield return new WaitForSeconds(attackInterval.Float);
        StartCoroutine(AttackOnInterval(entity));
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        // The range for this trigger is controller by SphereCollider/Radius
        if (other.TryGetComponent(out EntityIS entity) && entity is IDamageableIS)
        {
            StartCoroutine(AttackOnInterval(entity));
            Debug.Log("An IDamageable entity in range! " + entity);
        }
    }
}
