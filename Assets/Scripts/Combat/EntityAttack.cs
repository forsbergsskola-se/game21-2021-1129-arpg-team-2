using System.Collections;
using UnityEngine;

public class EntityAttack : MonoBehaviour, IAttack
{
    [SerializeField] private FloatValue basePower;
    [SerializeField] private FloatValue attackInterval;
    [SerializeField] private AudioSource attackSound;
    [SerializeField] private Weapon weapon;

    private bool attackOnGoing;
    private IDamageable attackTarget;
    [SerializeField] private GameObjectValue movementTarget;
    private GameObjectValue defaultValue;

    public FloatValue BasePower
    {
        get => basePower;
        set => basePower = value;
    }

    private void Update()
    {
        if (IsInWeaponRange() && !attackOnGoing && movementTarget.Value.TryGetComponent(out IDamageable entity))
        {
            attackTarget = entity;
            StartCoroutine(AttackOnInterval(attackTarget));
        }

        else if (!IsInWeaponRange() && attackOnGoing)
        {
            attackOnGoing = false;
            attackTarget = null;
            StopCoroutine(nameof(AttackOnInterval));
        }

        if (Input.GetMouseButtonDown(0) && movementTarget.Value.GetComponent<Entity>() is IDamageable && IsInWeaponRange())
        {
            attackTarget = movementTarget.Value.GetComponent<Entity>();
            StartCoroutine(AttackOnInterval(attackTarget));
        }
    }

    private bool IsInWeaponRange()
        => Mathf.Round(Vector3.Distance(transform.position, movementTarget.Value.transform.position)) <= weapon.Range;

    public void Attack(IDamageable thisTarget)
    {
        if (thisTarget == null) return;
        attackSound.Play();
        thisTarget.TakeDamage(BasePower.RuntimeValue);
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
