using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerJO : MonoBehaviour {
    [SerializeField] private GameObject ratPrefab;
    [SerializeField] private Vector3Value[] spawnPositions;
    [SerializeField] private FloatValue spawnInterval;
    private GameObject[] spawnedRats;

    private void Start()
    {
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            GameObject spawnedRat = Instantiate(ratPrefab, spawnPositions[i].Vector3, Quaternion.identity);
            spawnedRats[i] = spawnedRat;
            
            //Want to subscribe to action of rat death
            //Want to call respawn for dead rat after set interval
            //Will add +1 to amount of killed rat
            //Door to corresponding room subscribes to amount of killed rats
            //When killed rats matches kill criteria door opens
        }
    }

    private IEnumerator Respawn() {
        yield return new WaitForSeconds(spawnInterval.InitialValue);
        
    }
}