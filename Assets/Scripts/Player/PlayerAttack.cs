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

    public FloatValue BasePower
    {
        get => basePower;
        set => basePower = value;
    }

    private void Update()
    {
        if (IsInWeaponRange())
        {
            // RaycastHit hit;
            // if (target2 != null && 
            //     Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100))
            // {
            //     Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
            //         Color.red);
            //     target = hit.transform.gameObject.GetComponent<Entity>();
            //     StartCoroutine(AttackOnInterval(target));
            // }
            // else target2 = null;
            target = target2.Value.GetComponent<Entity>();
            StartCoroutine(AttackOnInterval(target));
        }

        if (target2 == null && attackOnGoing)
        {
            attackOnGoing = false;
            StopCoroutine(nameof(AttackOnInterval));
        }
    }

    private bool IsInWeaponRange()
        => Vector3.Distance(transform.position, target2.Value.transform.position) <= weapon.Range;

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
