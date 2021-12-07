using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Action<Enemy> OnDeath;
    // [SerializeField] private FloatValue currentHealth;
    // private float health;
    private Renderer render;
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    private Color defaultColor;
    private float redFlashInterval = .5f;
    private Health enemyHealth;
    
    public int SpawnIndex { get; private set; }
    // public FloatValue CurrentHealth { get => currentHealth; set => currentHealth = value; }

    private void Awake()
    {
        render = GetComponent<Renderer>();
        defaultColor = render.material.color;
        enemyHealth = GetComponent<Health>();
    }

    public void Spawn(int index, SpawnPoint spawnPoint)
    {
        SpawnIndex = index;
        transform.position = spawnPoint.transform.position;
        transform.rotation = Quaternion.identity;
        // health = currentHealth.InitialValue;
        gameObject.SetActive(true);
    }

    public void TakeDamage(float damage)
    {
        FlashRed();
        // CurrentHealth.RuntimeValue -= damage;
        // health -= damage;
        enemyHealth.TakeDamage(damage);
        if (enemyHealth.CurrentHealth.RuntimeValue <= 0f)
        {
            gameObject.SetActive(false);
            OnDeath?.Invoke(this);
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
}
