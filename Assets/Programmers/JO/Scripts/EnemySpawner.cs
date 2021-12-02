using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPooler))]
public class EnemySpawner : MonoBehaviour {
    [SerializeField] private SpawnPoint[] spawnPositions;
    [SerializeField] private FloatValue spawnInterval;
    [SerializeField] private EnemyJO enemyPrefab;
    private EnemyPooler objectPool;
    private List<GameObject> _spawnedObjects;

    private void Start() {
        objectPool = GetComponent<EnemyPooler>();
        objectPool.Setup(spawnPositions.Length, enemyPrefab);
        
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

    private IEnumerator Respawn(int index) {
        yield return new WaitForSeconds(spawnInterval.InitialValue);
        //SpawnFromPool(); <- should contain index of correct spawnPosition
    }

    private void SpawnFromPool(int index) {
        EnemyJO objectFromPool = objectPool.GetPooledObject(); 
        if (objectFromPool != null) {
            objectFromPool.transform.position = spawnPositions[index].transform.position;
            objectFromPool.transform.rotation = Quaternion.identity;
            objectFromPool.gameObject.SetActive(true);
        }
    }
}
