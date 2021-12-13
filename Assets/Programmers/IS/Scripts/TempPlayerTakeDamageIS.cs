using UnityEngine;

public class TempPlayerTakeDamageIS : MonoBehaviour
{
    // Literally just using this to inflict damage on player
    [SerializeField] private float damageForTesting;

    private Health health;
    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void OnMouseUp()
    {
        Debug.Log("Make player take damage!");
        health.TakeDamage(damageForTesting);
        Debug.Log("Health after damage: " + health.CurrentHealth.RuntimeValue);
    }
}
