using UnityEngine;
using System;

public class Health : MonoBehaviour, IDamageable {
    public Action<float> OnTakeDamage;
    [SerializeField] private CharStats charStats;
    [SerializeField] private float maxHealth;
   
    public GameEvent entityDeath;
    public GameEventListener deathListner;
    [SerializeField] private FloatValue currentHealth;

    public CharStats CharStats
    {
        get => charStats;
        set => charStats = value;
    }

    public FloatValue CurrentHealth
    {
        get => currentHealth; 
        set => currentHealth = value;
    }
    
    // Flash red when taking damage
    private Renderer render;
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    private Color defaultColor;
    private float redFlashInterval = .5f;
    
    private void Awake()
    {
        render = GetComponentInChildren<Renderer>();
        defaultColor = render.material.color;

        if (charStats == null)
        {
            charStats = ScriptableObject.CreateInstance<CharStats>();
            charStats.CurrentHealth = maxHealth;
            charStats.MaxHealth = maxHealth;
        }
        else charStats.CurrentHealth = charStats.MaxHealth;

        if (entityDeath == null)
        {
            entityDeath = ScriptableObject.CreateInstance<GameEvent>();
            deathListner.Event = entityDeath;
        }
    }
    
    public void TakeDamage(float damage)
    {
        FlashRed();
        charStats.CurrentHealth -= damage;

        if (charStats.CurrentHealth <= 0f)
        {
            entityDeath.Raise();
        }

        OnTakeDamage?.Invoke(damage);
    }

    public void ResetHealth() 
    {
        charStats.CurrentHealth = charStats.MaxHealth;
    }

    // (Hopefully) temporary

    private void FlashRed()
    {
        render.material.SetColor(Color1, Color.red);
        Invoke(nameof(SetToDefaultColor), redFlashInterval);
    }

    // (Hopefully) temporary

    private void SetToDefaultColor()
    {
        render.material.SetColor(Color1, defaultColor);
    }
}


