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

    private GameEvent isAttacking;
    public GameEvent IsAttacking => isAttacking;

    private void Awake()
    {
        attackOnGoing = false;
        isAttacking = ScriptableObject.CreateInstance<GameEvent>();
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
        if(!weapon.Ranged) thisTarget.TakeDamage(weapon.Power);
    }

    private IEnumerator AttackOnInterval(IDamageable entity)
    {
        attackOnGoing = true;
        while (entity.CharStats.CurrentHealth > 0f)
        {
            Attack(entity);
            isAttacking.Raise();
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
