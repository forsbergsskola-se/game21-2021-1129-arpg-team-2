using UnityEngine;
using UnityEngine.AI;

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

        Debug.Log("Entity taking damage! " + CurrentHealth.RuntimeValue);
        
        if (CurrentHealth.RuntimeValue <= 0f)
        {
            entityStatus = EntityStatus.Destroyed;
            entityDie.Raise();
        }
    }

    public void OnEntityDie()
    {
        destroySound.Play();
        DisableAsObstacle();
    }

    private void DisableAsObstacle()
    {
        NavMeshObstacle obstacleMesh = GetComponent<NavMeshObstacle>();
        BoxCollider collider = GetComponent<BoxCollider>();
        if (obstacleMesh != null && collider != null)
        {
            obstacleMesh.enabled = false;
            collider.enabled = false;
        }
    }
}
