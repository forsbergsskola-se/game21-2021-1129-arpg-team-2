using System;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttack
{
    [Header("Modifiers")]
    [SerializeField] private CharStats playerStats;
    [SerializeField] private Weapon weapon;
    
    [Header("Dependencies")]
    [SerializeField] private AudioSource attackSound;
    [SerializeField] private GameEvent onPlayerAttack;
    [SerializeField] private BooleanValue attackOnGoing;
    [SerializeField] private GameObjectValue movementTarget;

    private IDamageable attackTarget;
    private GameObjectValue defaultValue;

    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && movementTarget.Value != null)
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
            animator.SetBool("Is attacking", true);
        }

        else if (!IsInWeaponRange() && attackOnGoing.BoolValue) StopAttacking();
        else animator.SetBool("Is attacking", false);
    }

    private void StopAttacking()
    {
        attackOnGoing.BoolValue = false;
        attackTarget = null;
        StopCoroutine(nameof(AttackOnInterval));
    }

    private bool IsInWeaponRange()
    {
        if (movementTarget.Value != null)
        {
            return Mathf.Round(Vector3.Distance(transform.position, movementTarget.Value.transform.position)) <= weapon.Range;
        }
        
        return false;
    }
      

    public void Attack(IDamageable thisTarget)
    {
        attackSound.Play();
        float damage = playerStats.Attack + weapon.Power;
        thisTarget.TakeDamage(damage);
        onPlayerAttack.Raise();
    }

    private IEnumerator AttackOnInterval(IDamageable entity)
    {
        attackOnGoing.BoolValue = true;
        while (entity.CharStats.CurrentHealth > 0f)
        {
            Attack(entity);
            if (attackOnGoing.BoolValue) yield return new WaitForSeconds(playerStats.AttackSpeed);
            else yield break;
        }
    }
}
