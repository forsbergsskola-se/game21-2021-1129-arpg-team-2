using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerJo : MonoBehaviour {
    [SerializeField] private Vector3Value[] spawnPositions;
    [SerializeField] private FloatValue spawnInterval;
    private List<GameObject> _spawnedObjects;

    private void Start() {
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

    public int NumberOfObjects() {
        return spawnPositions.Length;
    }

    private IEnumerator Respawn(int index) {
        yield return new WaitForSeconds(spawnInterval.InitialValue);
        //SpawnFromPool(); <- should contain index of correct spawnPosition
    }

    private void SpawnFromPool(int index) {
        GameObject objectFromPool = ObjectPoolerJO.SharedInstance.GetPooledObject(); 
        if (objectFromPool != null) {
            objectFromPool.transform.position = spawnPositions[index].Vector3;
            objectFromPool.transform.rotation = Quaternion.identity;
            objectFromPool.SetActive(true);
        }
    }
}
