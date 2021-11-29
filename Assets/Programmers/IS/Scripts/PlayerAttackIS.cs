using System.Collections;
using UnityEngine;

public class PlayerAttackIS : MonoBehaviour, IAttackIS
{
    [SerializeField] private FloatValue basePower;
    [SerializeField] private FloatValue attackInterval;

    public FloatValue BasePower
    {
        get => basePower;
        set => basePower = value;
    }

    public void Attack(IDamageableIS thisTarget)
    {
        thisTarget.TakeDamage(BasePower);
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
