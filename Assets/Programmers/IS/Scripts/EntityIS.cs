using UnityEngine;

public class EntityIS : MonoBehaviour, IDamageableIS
{
    [SerializeField] private EntityType entityType;
    [SerializeField] private FloatVariableIS currentHealth;
    public FloatVariableIS CurrentHealth { get => currentHealth; set => currentHealth = value; }

    public void TakeDamage(FloatVariableIS damage)
    {
        CurrentHealth.RuntimeValue -= damage.RuntimeValue;
        Debug.Log("Entity is taking damage! " + CurrentHealth.RuntimeValue);
    }
}
