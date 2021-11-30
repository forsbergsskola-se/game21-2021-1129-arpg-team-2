using UnityEngine;

public class EntityIS : MonoBehaviour, IDamageableIS
{
    [SerializeField] private EntityType entityType;
    [SerializeField] private EntityStatus entityStatus;
    [SerializeField] private FloatValue currentHealth;
    [SerializeField] private GameEventIS entityDie;
    [SerializeField] private AudioSource destroySound;
    
    public FloatValue CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public EntityStatus CurrentStatus { get => entityStatus; set => entityStatus = value; }

    public void TakeDamage(FloatValue damage)
    {
        CurrentHealth.RuntimeValue -= damage.RuntimeValue;
        if (CurrentHealth.RuntimeValue <= 0f)
        {
            entityStatus = EntityStatus.Destroyed;
            entityDie.Raise();
        }
    }

    public void OnEntityDie() => destroySound.Play();
}
