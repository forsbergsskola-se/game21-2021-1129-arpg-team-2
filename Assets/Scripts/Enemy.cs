using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour, IDamageable
{
    public Action<Enemy> OnDeath; //Important
    [SerializeField] private FloatValue currentHealth;
    [SerializeField] private AudioSource deathSound;
    private float health;
    private Renderer render;
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    private Color defaultColor;
    private float redFlashInterval = .5f;
    
    public int SpawnIndex { get; private set; } //Important
    public FloatValue CurrentHealth { get => currentHealth; set => currentHealth = value; }

    private void Awake()
    {
        render = GetComponent<Renderer>();
        defaultColor = render.material.color;
    }

    public void Spawn(int index, SpawnPoint spawnPoint) //Important
    {
        SpawnIndex = index;
        transform.position = spawnPoint.transform.position;
        transform.rotation = Quaternion.identity;
        health = currentHealth.InitialValue;
        gameObject.SetActive(true);
    }

    public void TakeDamage(float damage)
    {
        FlashRed();
        CurrentHealth.RuntimeValue -= damage;
        health -= damage;
        if (health <= 0f)
        {
            deathSound.Play();
            gameObject.SetActive(false); //Important happen on death
            OnDeath?.Invoke(this); //Important happen on death
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
