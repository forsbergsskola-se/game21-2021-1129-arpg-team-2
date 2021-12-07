using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Action<Enemy> OnDeath;
    public int SpawnIndex { get; private set; }
    private Health enemyHealth;
    private GameEventListener listener;

    private void Awake()
    {
        enemyHealth = GetComponent<Health>();
        enemyHealth.entityDeath = ScriptableObject.CreateInstance<GameEvent>();
        listener = GetComponent<GameEventListener>();
        listener.Event = enemyHealth.entityDeath;
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
        Debug.Log("OnEnemyDeath fires");
        gameObject.SetActive(false);
        OnDeath?.Invoke(this);
    }
}
