using System.Collections;
using System.Linq;
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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsTargetInRange())
            {
                Debug.Log("Target acquired, ready to attack");
                StartCoroutine(AttackOnInterval(target));
            }
        }

        if (!IsTargetInRange() && attackOnGoing)
        {
            Debug.Log("Stopping active coroutine...");
            attackOnGoing = false;
        }
    }

    private bool IsTargetInRange()
    {
        var result = false;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            if (hit.transform.CompareTag("Destructible"))
            {
                result = true;
                target = hit.transform.gameObject.GetComponent<Entity>();
            }
        }

        return result;
    }
    
}
