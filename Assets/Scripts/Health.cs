using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
   
    public GameEvent entityDeath;
    [SerializeField] private FloatValue currentHealth;
    public FloatValue CurrentHealth { get => currentHealth; set => currentHealth = value; }
    
    // Flash red when taking damage
    private Renderer render;
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    private Color defaultColor;
    private float redFlashInterval = .5f;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        defaultColor = render.material.color;
<<<<<<< Updated upstream

=======
<<<<<<< HEAD
        currentHealth = ScriptableObject.CreateInstance<FloatValue>();
        currentHealth.RuntimeValue = maxHealth;
        currentHealth.InitialValue = maxHealth;
    }

=======

>>>>>>> Stashed changes
        if (CurrentHealth == null) currentHealth = ScriptableObject.CreateInstance<FloatValue>();
        
        currentHealth.RuntimeValue = maxHealth;
        currentHealth.InitialValue = maxHealth;
    }
    
<<<<<<< Updated upstream
=======
>>>>>>> 50934a7b1f8d070050e55dbac9d892db4acf7d61
>>>>>>> Stashed changes
    public void TakeDamage(float damage)
    {
        FlashRed();
        CurrentHealth.RuntimeValue -= damage;

        if (CurrentHealth.RuntimeValue <= 0f)
        {
            entityDeath.Raise();
            Debug.Log("Event has been raised");
        }
        
        Debug.Log(this.gameObject + ": " + CurrentHealth.RuntimeValue);
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
