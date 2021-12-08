using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    public GameEvent entityDeath;
    private FloatValue currentHealth;
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
        currentHealth = ScriptableObject.CreateInstance<FloatValue>();
        currentHealth.RuntimeValue = maxHealth;
        currentHealth.InitialValue = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        FlashRed();
        CurrentHealth.RuntimeValue -= damage;

        Debug.Log("entityDeath event: " + entityDeath);
        
        if (CurrentHealth.RuntimeValue <= 0f) entityDeath.Raise();
        Debug.Log(this.gameObject + ": " + CurrentHealth);
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
