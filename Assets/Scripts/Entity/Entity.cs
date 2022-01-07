using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour, IDamageable
{
    [SerializeField] private EntityType entityType;
    [SerializeField] private float maxHealth;
    [SerializeField] private ParticleSystem destructionParticlesPrefab;
    private FloatValue currentHealth;
    private float redFlashInterval = .5f;
    private Renderer render;
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    private Color defaultColor;
    private CoinSpawner coinspawner;
    private CarrotSpawner _carrotSpawner;

    public FloatValue CurrentHealth { get => currentHealth; set => currentHealth = value; }

    public CharStats CharStats { get; set; }

    private void Awake()
    {
        coinspawner = GetComponent<CoinSpawner>();
        _carrotSpawner = GetComponent<CarrotSpawner>();
        render = GetComponent<Renderer>();
        defaultColor = render.material.color;
        
        CharStats = ScriptableObject.CreateInstance<CharStats>();
        CharStats.MaxHealth = maxHealth;
        CharStats.CurrentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        FlashRed();
        CharStats.CurrentHealth -= damage;

        Debug.Log("Entity taking damage: " + CharStats.CurrentHealth);

        if (CharStats.CurrentHealth <= 0f)
        {
            OnEntityDie();
        }
    }

    private void FlashRed()
    {
        render.material.SetColor(Color1, Color.red);
        Invoke(nameof(SetToDefaultColor), redFlashInterval);
    }

    private void SetToDefaultColor()
    {
        render.material.SetColor(Color1, defaultColor);
    }

    public void OnEntityDie()
    {
        DisableAsObstacle();
        VisualDestruction();
        
        if ( coinspawner != null)
        {
            coinspawner.SpawnFromPool();
        }

        if (_carrotSpawner != null)
        {
            _carrotSpawner.SpawnFromPool();
        }
    }

    private void DisableAsObstacle()
    {
        NavMeshObstacle obstacleMesh = GetComponent<NavMeshObstacle>();
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();
        
        if (obstacleMesh != null && capsuleCollider != null)
        {
            obstacleMesh.enabled = false;
            capsuleCollider.enabled = false;
        }
    }

    private void VisualDestruction()
    {
        MeshRenderer entityMesh = GetComponent<MeshRenderer>();
        ParticleSystem destructionParticles = Instantiate(destructionParticlesPrefab, this.transform.position, Quaternion.identity);
        destructionParticles.Play();
        entityMesh.enabled = false;
    }
}
