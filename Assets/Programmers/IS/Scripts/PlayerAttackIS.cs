using UnityEngine;

public class PlayerAttackIS : MonoBehaviour, IAttackIS
{
    [SerializeField] private FloatValue power;
    public FloatValue Power { get; set; }
    private IDamageableIS target;

    public void Attack(IDamageableIS someTarget)
    {
        someTarget.TakeDamage(Power.Float);
    }
    
    private void Update()
    {
        Debug.Log("What is target " + target);
        if (target is not null && Input.GetMouseButtonDown(0))
        {
            Attack(target);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        target = null;
        // The range for this trigger is controller by SphereCollider/Radius
        if (other.TryGetComponent(out EntityIS entity) && entity is IDamageableIS)
        {
            target = entity;
            Debug.Log("An IDamageable entity in range! " + target);
        }
    }
}
