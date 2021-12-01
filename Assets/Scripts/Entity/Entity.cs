using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour, IDamageable
{
    [SerializeField] private EntityType entityType;
    [SerializeField] private FloatValue currentHealth;
    [SerializeField] private GameEvent entityDie;
    [SerializeField] private ParticleSystem destructionParticlesPrefab;
    private Renderer render;
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    private Color defaultColor;

    public FloatValue CurrentHealth { get => currentHealth; set => currentHealth = value; }

    private void Awake()
    {
        render = GetComponent<Renderer>();
        defaultColor = render.material.color;
    }

    public void TakeDamage(FloatValue damage)
    {
        FlashRed();
        CurrentHealth.RuntimeValue -= damage.RuntimeValue;

        Debug.Log("Entity taking damage: " + CurrentHealth.RuntimeValue);

        if (CurrentHealth.RuntimeValue <= 0f)
        {
            OnEntityDie();
        }
    }

    private void FlashRed()
    {
        render.material.SetColor(Color1, Color.red);
        render.material.SetColor(Color1, defaultColor);
    }

    public void OnEntityDie()
    {
        DisableAsObstacle();
        StartCoroutine(VisualDestruction());
    }

    private void DisableAsObstacle()
    {
        NavMeshObstacle obstacleMesh = GetComponent<NavMeshObstacle>();
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        if (obstacleMesh != null && boxCollider != null)
        {
            obstacleMesh.enabled = false;
            boxCollider.enabled = false;
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
