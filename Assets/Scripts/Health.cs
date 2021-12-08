using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
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
        
        // GameObject HealthBar = GameObject.Find("EnemyHealthBar");
        // HealthBar.SetActive(false);
    }

    void OnMouseEnter()
    {
        GameObject.FindWithTag("HealthBar").SetActive(true);
        
    }

    void OnMouseExit()
    {
       GameObject.FindWithTag("HealthBar").SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        FlashRed();
        currentHealth.RuntimeValue -= damage;

        Debug.Log("entityDeath event: " + entityDeath);
        
        if (currentHealth.RuntimeValue <= 0f) entityDeath.Raise();
        Debug.Log(this.gameObject + ": " + currentHealth.RuntimeValue);
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
