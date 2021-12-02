using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerJO : MonoBehaviour {
    //[SerializeField] private GameObject ratPrefab;
    [SerializeField] private Vector3Value[] spawnPositions;
    [SerializeField] private FloatValue spawnInterval;
    private List<GameObject> spawnedObjects;

    private void Start() {
        for (int i = 0; i < spawnPositions.Length; i++) {
            //Instantiate(ratPrefab, spawnPositions[i].Vector3, Quaternion.identity);
            GameObject objectFromPool = ObjectPoolerJO.SharedInstance.GetPooledObject(); 
            if (objectFromPool != null) {
                objectFromPool.transform.position = spawnPositions[i].Vector3;
                objectFromPool.transform.rotation = Quaternion.identity;
                objectFromPool.SetActive(true);
            }
        }

        //Want to subscribe to action of rat death
        //Want to call respawn for dead rat after set interval
        //Will add +1 to amount of killed rat
        //Door to corresponding room subscribes to amount of killed rats
        //When killed rats matches kill criteria door opens

        //Add object pooling, will be in a list
    }

    public int numberOfObjects() {
        return spawnPositions.Length;
    }

    private IEnumerator Respawn(int index) {
        yield return new WaitForSeconds(spawnInterval.InitialValue);
        //spawnedRats[index] = Instantiate(ratPrefab, spawnPositions[index].Vector3, Quaternion.identity);
    }

    private void SpawnFromPool() {
        GameObject obj = ObjectPoolerJO.SharedInstance.GetPooledObject(); 
        if (obj != null) {
           // obj.transform.position = turret.transform.position;
           // obj.transform.rotation = turret.transform.rotation;
            obj.SetActive(true);
        }
    }
}
