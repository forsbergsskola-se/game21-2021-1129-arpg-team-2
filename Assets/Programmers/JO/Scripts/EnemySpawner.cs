using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPooler))]
public class EnemySpawner : MonoBehaviour {
    public Action<int> OnEnemyDeath;
    [SerializeField] private SpawnPoint[] spawnPositions;
    [SerializeField] private FloatValue spawnInterval;
    [SerializeField] private EnemyJO enemyPrefab;
    private EnemyPooler enemyPool;
    private List<GameObject> _spawnedObjects;
    private int deathCount;
    public int SpawnPointsCount {
        get { return spawnPositions.Length; }
    }
    
    private void Start() {
        enemyPool = GetComponent<EnemyPooler>();
        enemyPool.Setup(spawnPositions.Length, enemyPrefab);
        
        for (int i = 0; i < spawnPositions.Length; i++) {
            SpawnFromPool(i);
        }

        //Want to subscribe to action of rat death
        //Want to call respawn for dead rat after set interval
        //Will add +1 to amount of killed rat
        //Door to corresponding room subscribes to amount of killed rats
        //When killed rats matches kill criteria door opens

        //Add object pooling, will be in a list
    }

    private IEnumerator Respawn(int spawnIndex) {
        yield return new WaitForSeconds(1);
        Debug.Log("Respawning enemy on " + spawnIndex);
        SpawnFromPool(spawnIndex);
    }

    private void SpawnFromPool(int index) {
        EnemyJO enemy = enemyPool.GetPooledObject(); 
        if (enemy != null) {
            enemy.Spawn(index, spawnPositions[index]);
            enemy.OnDeath += EnemyDied;
        }
    }

    private void EnemyDied(EnemyJO enemy) {
        deathCount++;
        OnEnemyDeath?.Invoke(deathCount);
        StartCoroutine(Respawn(enemy.SpawnIndex));
    }
}
