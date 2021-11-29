using UnityEngine;

public class EntityIS : MonoBehaviour, IDamageableIS
{
    [SerializeField] private EntityType entityType;
    [SerializeField] private EntityStatus entityStatus;
    [SerializeField] private FloatVariableIS currentHealth;
    [SerializeField] private GameEventIS entityDie;
    [SerializeField] private AudioSource destroySound;
    
    public FloatVariableIS CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public EntityStatus CurrentStatus { get => entityStatus; set => entityStatus = value; }

    public void TakeDamage(FloatVariableIS damage)
    {
        CurrentHealth.RuntimeValue -= damage.RuntimeValue;
        Debug.Log("Entity is taking damage! " + CurrentHealth.RuntimeValue);

        if (currentHealth.RuntimeValue <= 0f)
        {
            entityStatus = EntityStatus.Destroyed;

            Debug.Log("EntityDie event raised");
            
            entityDie.Raise();
        }
    }

    public void OnEntityDie()
    {
        destroySound.Play();
    }
}
