using System.Collections;
using UnityEngine;

public class EntityAttack : MonoBehaviour, IAttack
{
    [SerializeField] private FloatValue attackInterval;
    [SerializeField] private AudioSource attackSound;
    [SerializeField] private Weapon weapon;

    private bool _attackOnGoing;
    private IDamageable _attackTarget;
    [SerializeField] private GameObjectValue movementTarget;
    private GameObjectValue _defaultValue;


    private void Update()
    {
        if (IsInWeaponRange() && !_attackOnGoing && movementTarget.Value.TryGetComponent(out IDamageable entity))
        {
            _attackTarget = entity;
            StartCoroutine(AttackOnInterval(_attackTarget));
        }

        else if (!IsInWeaponRange() && _attackOnGoing)
        {
            _attackOnGoing = false;
            _attackTarget = null;
            StopCoroutine(nameof(AttackOnInterval));
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
        _attackOnGoing = true;
        while (entity.CurrentHealth.RuntimeValue > 0f)
        {
            Attack(entity);
            if (_attackOnGoing) yield return new WaitForSeconds(attackInterval.RuntimeValue);
            else yield break;
        }
    }
}
