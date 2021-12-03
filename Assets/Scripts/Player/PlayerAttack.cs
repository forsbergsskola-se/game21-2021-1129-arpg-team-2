using System;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttack
{
    [SerializeField] private FloatValue basePower;
    [SerializeField] private FloatValue attackInterval;
    [SerializeField] private AudioSource swordAttack;
    [SerializeField] private Weapon weapon;

    private bool attackOnGoing;
    private IDamageable target;
    [SerializeField] private GameObjectValue target2;
    private GameObjectValue defaultValue;

    public FloatValue BasePower
    {
        get => basePower;
        set => basePower = value;
    }

    private void Update()
    {
        if (IsInWeaponRange() && !attackOnGoing)
        {
            target = target2.Value.GetComponent<Entity>();
            StartCoroutine(AttackOnInterval(target));
        }

        else if (!IsInWeaponRange() && attackOnGoing)
        {
            attackOnGoing = false;
            target = null;
            StopCoroutine(nameof(AttackOnInterval));
        }
        
        if (Input.GetMouseButtonDown(0) && target2.Value.GetComponent<Entity>() is IDamageable && IsInWeaponRange())
        {
            target = target2.Value.GetComponent<Entity>();
            StartCoroutine(AttackOnInterval(target));
            Debug.Log(target.CurrentHealth.RuntimeValue);
        }
    }

    private bool IsInWeaponRange()
        => Mathf.Round(Vector3.Distance(transform.position, target2.Value.transform.position)) <= weapon.Range;

    public void Attack(IDamageable thisTarget)
    {
        if (thisTarget == null) return;
        swordAttack.Play();
        thisTarget.TakeDamage(BasePower);
    }

    private IEnumerator AttackOnInterval(IDamageable entity)
    {
        attackOnGoing = true;
        while (entity.CurrentHealth.RuntimeValue > 0f)
        {
            Attack(entity);
            if (attackOnGoing) yield return new WaitForSeconds(attackInterval.RuntimeValue);
            else yield break;
        }
    }
}
