using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttack
{
    [Header("Modifiers")]
    [SerializeField] private CharStats playerStats;
    [SerializeField] private Weapon weapon;
    [SerializeField] private FloatValue basePower;
    [SerializeField] private FloatValue attackInterval;
    
    [Header("Dependencies")]
    [SerializeField] private AudioSource attackSound;
    [SerializeField] private GameEvent onPlayerAttack;
    [SerializeField] private BooleanValue attackOnGoing;
    [SerializeField] private GameObjectValue movementTarget;

    private IDamageable attackTarget;
    private GameObjectValue defaultValue;

    public FloatValue BasePower
    {
        get => basePower;
        set => basePower = value;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            
            if (movementTarget.Value.GetComponent<Entity>() is IDamageable && IsInWeaponRange())
            {
                attackTarget = movementTarget.Value.GetComponent<Entity>();
                StartCoroutine(AttackOnInterval(attackTarget));
            }    
        }

        else if (IsInWeaponRange() && !attackOnGoing.BoolValue && movementTarget.Value.TryGetComponent(out IDamageable entity))
        {
            attackTarget = entity;
            StartCoroutine(AttackOnInterval(attackTarget));
        }

        else if (!IsInWeaponRange() && attackOnGoing.BoolValue) StopAttacking();
    }

    private void StopAttacking()
    {
        attackOnGoing.BoolValue = false;
        attackTarget = null;
        StopCoroutine(nameof(AttackOnInterval));
    }

    private bool IsInWeaponRange()
        => Mathf.Round(Vector3.Distance(transform.position, movementTarget.Value.transform.position)) <= weapon.Range;

    public void Attack(IDamageable thisTarget)
    {
        attackSound.Play();
        thisTarget.TakeDamage(BasePower.RuntimeValue);
        onPlayerAttack.Raise();
    }

    private IEnumerator AttackOnInterval(IDamageable entity)
    {
        attackOnGoing.BoolValue = true;
        while (entity.CurrentHealth.RuntimeValue > 0f)
        {
            Attack(entity);
            if (attackOnGoing.BoolValue) yield return new WaitForSeconds(attackInterval.RuntimeValue);
            else yield break;
        }
    }
}
