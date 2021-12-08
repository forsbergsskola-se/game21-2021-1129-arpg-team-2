using System;
using System.Collections;
using UnityEngine;

public class HealthRegeneration : MonoBehaviour
{
    [SerializeField] private FloatValue playerHealth;
    [SerializeField] [Range(0.1f, 1f)]private float healthThreshold;
    [SerializeField] private float regenerationRate;
    [SerializeField] private float regenerationTime;

    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    public void RegenerateHealth()
    {
        StartCoroutine(Heal());
    }

    private IEnumerator Heal()
    {
        Debug.Log("Health is Regenerating");
        health.enabled = false;
        
        playerHealth.RuntimeValue += regenerationRate;
        
        if (playerHealth.RuntimeValue >= playerHealth.InitialValue * healthThreshold)
        {
            playerHealth.RuntimeValue = playerHealth.InitialValue;
            health.enabled = true;
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(regenerationTime / regenerationRate);
            
            Debug.Log(regenerationTime / regenerationRate);
            Debug.Log(playerHealth.RuntimeValue);
            
            StartCoroutine(Heal());
        }
    }

}
