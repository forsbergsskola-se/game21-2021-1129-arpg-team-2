using System.Collections;
using UnityEngine;

public class PlayerAttackIS : MonoBehaviour, IAttackIS
{
    [SerializeField] private FloatValue basePower;
    [SerializeField] private FloatValue attackInterval;
    [SerializeField] private AudioSource swordAttack;

    public FloatValue BasePower
    {
        get => basePower;
        set => basePower = value;
    }

    public void Attack(IDamageableIS thisTarget)
    {
        // swordAttack.Play();
        Debug.Log("gimme BasePower: " + BasePower);
        Debug.Log("gimme BasePower.Runtime: " + BasePower.RuntimeValue);
        thisTarget.TakeDamage(BasePower);
    }

    private IEnumerator AttackOnInterval(IDamageableIS entity)
    {
        Attack(entity);
        yield return new WaitForSeconds(attackInterval.RuntimeValue);
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

    // public void OnDestructibleDestroyed()
    // {
    //     Debug.Log("Attack coroutine stopping...");
    //     StopCoroutine(coroutine);
    // }
}
