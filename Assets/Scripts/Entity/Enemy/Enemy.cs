using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Action<Enemy> OnDeath;
    public Action<bool> InCombatChanged;
    public int SpawnIndex { get; private set; }
    [SerializeField] private float inCombatAfterDamageTime = 2;
    private Health enemyHealth;
    private EntityAttack enemyAttack;
    private GameEventListener listener;
    private bool isAttacking;
    private float tookDamageTimer;
    public bool InCombat { get; private set; }

    private void Awake()
    {
        enemyHealth = GetComponent<Health>();
        enemyHealth.entityDeath = ScriptableObject.CreateInstance<GameEvent>();
        enemyAttack = GetComponent<EntityAttack>();
        listener = GetComponent<GameEventListener>();
        listener.Event = enemyHealth.entityDeath;
        enemyHealth.OnTakeDamage += TookDamage;
        enemyAttack.OnAttackingChanged += AttackingChanged;
    }

    private void OnDestroy() {
        enemyHealth.OnTakeDamage -= TookDamage;
        enemyAttack.OnAttackingChanged -= AttackingChanged;
    }

    private void Update() {
        if (tookDamageTimer > 0) {
            tookDamageTimer -= Time.deltaTime;
            if (tookDamageTimer <= 0) {
                EvaluateIfInCombat();
            }
        }
    }

    public void Spawn(int index, SpawnPoint spawnPoint)
    {
        SpawnIndex = index;
        transform.position = spawnPoint.transform.position;
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(true);
    }

    public void OnEnemyDeath()
    {
        gameObject.SetActive(false);
        OnDeath?.Invoke(this);
    }

    private void AttackingChanged(bool attacking)
    {
        isAttacking = attacking;
        EvaluateIfInCombat();
    }
    
    private void TookDamage(float damage)
    {
        tookDamageTimer = inCombatAfterDamageTime;
        EvaluateIfInCombat();
    }

    private void EvaluateIfInCombat()
    {
        if (InCombat)
        {
            if (!isAttacking && tookDamageTimer <= 0)
            {
                InCombat = false;
                InCombatChanged?.Invoke(false);
            }
        }
        else
        {
            if (isAttacking || tookDamageTimer > 0)
            {
                InCombat = true;
                InCombatChanged?.Invoke(true);
            }
        }
    }
}
