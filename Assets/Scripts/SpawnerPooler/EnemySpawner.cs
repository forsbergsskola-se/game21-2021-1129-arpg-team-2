using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Action<int> OnEnemyDeath;
    public SpawnPoint[] spawnPositions;
    [SerializeField] private FloatValue spawnInterval;
    [SerializeField] private Enemy enemyPrefab;
    private Pooler<Enemy> enemyPool;
    private List<GameObject> spawnedEnemies;
    private int deathCount;
    public int SpawnPointsCount => spawnPositions.Length;

    private void Start()
    {
        enemyPool = new Pooler<Enemy>();
        enemyPool.Setup(spawnPositions.Length, enemyPrefab);
        
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            SpawnFromPool(i);
        }
    }

    private IEnumerator Respawn(int spawnIndex)
    {
        yield return new WaitForSeconds(spawnInterval.InitialValue);
        SpawnFromPool(spawnIndex);
    }

    private void SpawnFromPool(int index)
    {
        Enemy enemy = enemyPool.GetPooledObject(); 
        if (enemy != null)
        {
            enemy.Spawn(index, spawnPositions[index]);
            enemy.OnDeath += EnemyDied;
        }
    }

    private void EnemyDied(Enemy enemy)
    {
        deathCount++;
        enemyPool.Return(enemy);
        OnEnemyDeath?.Invoke(deathCount);
        
        if (spawnInterval != null)
        {
            StartCoroutine(Respawn(enemy.SpawnIndex));
        }
    }
}
