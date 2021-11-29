using System.Collections;
using UnityEngine;

public class PlayerAttackIS : MonoBehaviour, IAttackIS
{
    [SerializeField] private FloatVariableIS basePower;
    [SerializeField] private FloatValue attackInterval;
    [SerializeField] private AudioSource swordAttack;

    private IEnumerator coroutine;

    public FloatVariableIS BasePower
    {
        get => basePower;
        set => basePower = value;
    }

    public void Attack(IDamageableIS thisTarget)
    {
        swordAttack.Play();
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
            coroutine = AttackOnInterval(entity);
            StartCoroutine(coroutine);
            Debug.Log("An IDamageable entity in range! " + entity);
        }
    }

    public void OnDestructibleDestroyed()
    {
        Debug.Log("Attack coroutine stopping...");
        StopCoroutine(coroutine);
    }
}
