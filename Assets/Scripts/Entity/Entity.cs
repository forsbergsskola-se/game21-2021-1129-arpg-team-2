using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour, IDamageable
{
    [SerializeField] private EntityType entityType;
    [SerializeField] private float maxHealth;
    [SerializeField] private ParticleSystem destructionParticlesPrefab;
    [SerializeField] private CoinDropAA coinDropAA;
    private FloatValue currentHealth;
    private float redFlashInterval = .5f;
    private Renderer render;
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    private Color defaultColor;

    public FloatValue CurrentHealth { get => currentHealth; set => currentHealth = value; }

    public CharStats CharStats { get; set; }

    private void Awake()
    {
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
        if ( coinDropAA != null)
        {
            coinDropAA.DropCoin(transform);
        }
        DisableAsObstacle();
        StartCoroutine(VisualDestruction());
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

    private IEnumerator VisualDestruction()
    {
        MeshRenderer entityMesh = GetComponent<MeshRenderer>();
        ParticleSystem destructionParticles = Instantiate(destructionParticlesPrefab, this.transform.position, Quaternion.identity);
        destructionParticles.Play();
        yield return new WaitForSeconds(0.100f);
        entityMesh.enabled = false;
    }
}
