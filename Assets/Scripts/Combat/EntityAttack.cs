using System.Collections;
using System;
using UnityEngine;

public class EntityAttack : MonoBehaviour, IAttack {
    public Action<bool> OnAttackingChanged;
    [SerializeField] private FloatValue attackInterval;
    [SerializeField] private AudioSource attackSound;
    [SerializeField] private Weapon weapon;

    private bool attackOnGoing;
    private IDamageable _attackTarget;
    [SerializeField] private GameObjectValue movementTarget;
    private GameObjectValue _defaultValue;

    private void Awake()
    {
        attackOnGoing = false;
    }

    private void Update()
    {
        if (IsInWeaponRange() && !attackOnGoing && movementTarget.Value.TryGetComponent(out IDamageable entity))
        {
            _attackTarget = entity;
            StartCoroutine(AttackOnInterval(_attackTarget));
            OnAttackingChanged?.Invoke(true);
        }

        else if (!IsInWeaponRange() && attackOnGoing)
        {
            attackOnGoing = false;
            _attackTarget = null;
            StopCoroutine(nameof(AttackOnInterval));
            OnAttackingChanged?.Invoke(false);
        }
    }

    private bool IsInWeaponRange()
        => Mathf.Round(Vector3.Distance(transform.position, movementTarget.Value.transform.position)) <= weapon.Range;

    public void Attack(IDamageable thisTarget)
    {
        if (thisTarget == null) return;
        //attackSound.Play();
        thisTarget.TakeDamage(weapon.Power);
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

    private void OnDisable()
    {
        StopAllCoroutines();
        attackOnGoing = false;
    }
}
