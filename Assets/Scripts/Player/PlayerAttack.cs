using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttack
{
    [SerializeField] private FloatValue basePower;
    [SerializeField] private FloatValue attackInterval;
    [SerializeField] private AudioSource swordAttack;
    [SerializeField] private Weapon weapon;

    private IDamageable target;
    private bool attackOnGoing;

    public FloatValue BasePower
    {
        get => basePower;
        set => basePower = value;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsTargetInRange()) StartCoroutine(AttackOnInterval(target));
        if (target == null && attackOnGoing) attackOnGoing = false;
    }

    private bool IsTargetInRange()
    {
        var result = false;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            if (IsTarget(hit) && IsInWeaponRange(hit))
            {
                result = true;
                target = hit.transform.gameObject.GetComponent<Entity>();
            }
            else target = null;
        }
        return result;
    }

    private bool IsInWeaponRange(RaycastHit hit)
        => Vector3.Distance(transform.position, hit.transform.position) <= weapon.Range;

    private bool IsTarget(RaycastHit hit) => hit.transform.CompareTag("Destructible");
    
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
