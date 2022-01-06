using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemySpawner : MonoBehaviour
{
    [Serializable] private class RoomSpawnPoints {
        public SpawnPoint[] SpawnPoints;
    }
    
    [Header("Enemy spawn settings")]
    [SerializeField] private FloatValue spawnInterval;
    [SerializeField] private Enemy enemyPrefab;

    [Header("Rooms")]
    [SerializeField] private RoomSpawnPoints[] roomSpawns;
    
    public Action<int> OnEnemyDeath;
    public List <SpawnPoint> spawnPositions;
    private Pooler<Enemy> enemyPool;
    private List<GameObject> spawnedEnemies;
    public int SpawnPointsCount => spawnPositions.Count;

    private void Start()
    {
        AddSpawnPointsToOneList();
        enemyPool = new Pooler<Enemy>();
        enemyPool.Setup(spawnPositions.Count, enemyPrefab);
        
        for (int i = 0; i < spawnPositions.Count; i++)
        {
            SpawnFromPool(i);
        }
    }

    //Slightly unneccessary set up but makes it more clear for designers in inspector
    private void AddSpawnPointsToOneList()
    {
        for (int i = 0; i < roomSpawns.Length; i++)
        {
            for (int j = 0; j < roomSpawns[i].SpawnPoints.Length; j++)
            {
                if (roomSpawns[i].SpawnPoints[j] != null)
                {
                    spawnPositions.Add(roomSpawns[i].SpawnPoints[j]);
                }
            }
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
        enemyPool.Return(enemy);
        OnEnemyDeath?.Invoke(enemy.SpawnIndex);
        StartCoroutine(Respawn(enemy.SpawnIndex));
    }
}
