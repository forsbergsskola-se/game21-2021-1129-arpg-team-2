using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegeneration : MonoBehaviour
{
    [SerializeField] private FloatValue playerHealth;
    [SerializeField] private float regenerationRate;

    public void RegenerateHealth()
    {
        playerHealth.RuntimeValue = playerHealth.InitialValue;
    }

}
