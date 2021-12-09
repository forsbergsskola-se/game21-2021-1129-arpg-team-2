using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(PlayernavMesh))]
[RequireComponent(typeof(PlayerAttack))]
public class HealthRegeneration : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private FloatValue playerHealth;
    [SerializeField] [Range(0.1f, 1f)] private float healthThreshold;
    [SerializeField] private float regenerationRate;
    [SerializeField] private float regenerationTime;

    [Header("External Dependencies")]
    [SerializeField] private GameEvent playerRespawn;

    [SerializeField] private BooleanValue attackOnGoing;

    private Health _health;
    private PlayernavMesh _playernavMesh;
    private PlayerAttack _playerAttack;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playernavMesh = GetComponent<PlayernavMesh>();
    }

    public void RegenerateHealth()
    {
        playerHealth.RuntimeValue = 0;
        
        _health.enabled = false;
        _playerAttack.enabled = false;
        _playernavMesh.enabled = false;
        
        attackOnGoing.BoolValue = false;
        
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
            
            _health.enabled = true;
            _playerAttack.enabled = true;
            _playernavMesh.enabled = true;
            
            playerRespawn.Raise();
            
            yield return null;
        }
        else StartCoroutine(Heal());
    }

}
