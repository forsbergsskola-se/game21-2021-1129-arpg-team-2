using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(PlayernavMesh))]
[RequireComponent(typeof(PlayerAttack))]
public class HealthRegeneration : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private CharStats playerStats;
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
        playerStats.CurrentHealth = 0;
        
        _health.enabled = false;
        _playernavMesh.enabled = false;
        
        StartCoroutine(Heal());
    }

    private IEnumerator Heal()
    {
        yield return new WaitForSeconds(regenerationTime * playerStats.AttackSpeed/ regenerationRate);
        
        playerStats.CurrentHealth += regenerationRate;
        
        if ( playerStats.CurrentHealth >=  playerStats.MaxHealth * healthThreshold)
        {
            playerStats.CurrentHealth = playerStats.MaxHealth;
            
            _health.enabled = true;
            _playerAttack.enabled = true;
            _playernavMesh.enabled = true;
            
            playerRespawn.Raise();
            
            yield return null;
        }
        else StartCoroutine(Heal());
    }

}
