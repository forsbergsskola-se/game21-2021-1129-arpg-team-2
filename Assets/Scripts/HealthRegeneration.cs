using System.Collections;
using UnityEngine;

public class HealthRegeneration : MonoBehaviour
{
    [SerializeField] private FloatValue playerHealth;
    [SerializeField] [Range(0.1f, 1f)]private float healthThreshold;
    [SerializeField] private float regenerationRate;
    [SerializeField] private float regenerationTime;

    [SerializeField] private GameEvent playerRespawn;

    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    public void RegenerateHealth()
    {
        playerHealth.RuntimeValue = 0;
        health.enabled = false;
        StartCoroutine(Heal());
    }

    private IEnumerator Heal()
    {
        Debug.Log("Health is Regenerating");
        
        yield return new WaitForSeconds(regenerationTime / regenerationRate);
        
        playerHealth.RuntimeValue += regenerationRate;
        
        if (playerHealth.RuntimeValue >= playerHealth.InitialValue * healthThreshold)
        {
            playerHealth.RuntimeValue = playerHealth.InitialValue;
            health.enabled = true;
            playerRespawn.Raise();
            
            yield return null;
        }
        else StartCoroutine(Heal());
    }

}
