using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerAttackIS : MonoBehaviour, IAttackIS
{
    [SerializeField] private FloatValue basePower;
    [SerializeField] private FloatValue attackInterval;
    [SerializeField] private AudioSource swordAttack;
    [SerializeField] private WeaponIS weapon;

    private IDamageableIS target;

    public FloatValue BasePower
    {
        get => basePower;
        set => basePower = value;
    }

    public void Attack(IDamageableIS thisTarget)
    {
        if (thisTarget == null) return;
        swordAttack.Play();
        thisTarget.TakeDamage(BasePower);
    }

    private IEnumerator AttackOnInterval(IDamageableIS entity)
    {
        while (entity.CurrentHealth.RuntimeValue > 0f)
        {
            Attack(entity);
            yield return new WaitForSeconds(attackInterval.RuntimeValue);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsTargetInRange())
            {
                Debug.Log("Target acquired, ready to attack");
                StartCoroutine(AttackOnInterval(target));
            }
            else
            {
                Debug.Log("Target out of range");
            }
        }
    }

    private bool IsTargetInRange()
    {
        var result = false;
        var temp = FindObjectsOfType<EntityIS>().Where(x => x is IDamageableIS).ToList();
        for (var i = 0; i < temp.Count; i++)
        {
            var tempPos = temp[i].transform.position;
            result = Vector3.Distance(transform.position, tempPos) <= weapon.Range;
            if (result)
            {
                target = temp[i];
                break;
            }
        }

        if (!result) target = null;
        return result;
    }

    //
    
    // private void OnTriggerEnter(Collider other)
    // {
    //     // The range for this trigger is controller by SphereCollider/Radius
    //     if (other.TryGetComponent(out EntityIS entity) && entity is IDamageableIS)
    //     {
    //         StartCoroutine(AttackOnInterval(entity));
    //         Debug.Log("An IDamageable entity in range! " + entity);
    //     }
    // }
}
