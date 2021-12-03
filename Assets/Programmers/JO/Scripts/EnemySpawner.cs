using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPooler))]
public class EnemySpawner : MonoBehaviour
{
    public Action<int> OnEnemyDeath;
    [SerializeField] private SpawnPoint[] spawnPositions;
    [SerializeField] private FloatValue spawnInterval;
    [SerializeField] private EnemyJO enemyPrefab;
    private EnemyPooler enemyPool;
    private List<GameObject> _spawnedObjects;
    private int deathCount;
    public int SpawnPointsCount => spawnPositions.Length;

    private void Start()
    {
        enemyPool = GetComponent<EnemyPooler>();
        enemyPool.Setup(spawnPositions.Length, enemyPrefab);
        
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            SpawnFromPool(i);
        }
    }

    private IEnumerator Respawn(int spawnIndex)
    {
        yield return new WaitForSeconds(1); //should be changed to spawn interval
        SpawnFromPool(spawnIndex);
    }

    private void SpawnFromPool(int index)
    {
        EnemyJO enemy = enemyPool.GetPooledObject(); 
        if (enemy != null)
        {
            enemy.Spawn(index, spawnPositions[index]);
            enemy.OnDeath += EnemyDied;
        }
    }

    private void EnemyDied(EnemyJO enemy)
    {
        deathCount++;
        OnEnemyDeath?.Invoke(deathCount);
        StartCoroutine(Respawn(enemy.SpawnIndex));
    }
}
