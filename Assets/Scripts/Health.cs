using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    private FloatValue currentHealth;
    public FloatValue CurrentHealth { get => currentHealth; set => currentHealth = value; }
    // private float health;

    private void Awake()
    {
        currentHealth = ScriptableObject.CreateInstance<FloatValue>();
        currentHealth.RuntimeValue = maxHealth;
        currentHealth.InitialValue = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("CurrentHealth: " + CurrentHealth.RuntimeValue);
        CurrentHealth.RuntimeValue -= damage;
        
        // health -= damage;
        // if (health <= 0f)
        // {
        //     gameObject.SetActive(false);
        // }
    }
}
