using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EntityIS : MonoBehaviour, IDamageableIS
{
    [SerializeField] private EntityType entityType;
    [SerializeField] private EntityStatus entityStatus;
    [SerializeField] private FloatValue currentHealth;
    [SerializeField] private GameEventIS entityDie;
    [SerializeField] private AudioSource destroySound;
    [SerializeField] private ParticleSystem destructionParticlesPrefab;
    
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

    public void OnEntityDie()
    {
        destroySound.Play();
        DisableAsObstacle();
        StartCoroutine(VisualDestruction());
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

    private IEnumerator VisualDestruction()
    {
        //ParticleSystem destructionParticles = GetComponent<ParticleSystem>();
        MeshRenderer entityMesh = GetComponent<MeshRenderer>();

        ParticleSystem destructionParticles = Instantiate(destructionParticlesPrefab, this.transform.position, Quaternion.identity);
        destructionParticles.Play();

        Debug.Log("Particles spawned");
       /*if (destructionParticles != null)
        {
            destructionParticles.Play();
        }*/

        yield return new WaitForSeconds(0.100f);
        entityMesh.enabled = false;
    }
}
