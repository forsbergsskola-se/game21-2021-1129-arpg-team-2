using UnityEngine;

public class EntityIS : MonoBehaviour, IDamageableIS
{
    [SerializeField] private EntityType entityType;
    [SerializeField] private FloatValue maxHealth;
    public float CurrentHealth { get; set; }

    private void Awake()
    {
        CurrentHealth = maxHealth.Float;
    }

    public void TakeDamage(FloatValue damage)
    {
        CurrentHealth -= damage.Float;
        Debug.Log("Entity is taking damage! " + CurrentHealth);
    }
}
