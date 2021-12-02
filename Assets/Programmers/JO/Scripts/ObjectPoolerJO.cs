using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerJO : MonoBehaviour {
    public static ObjectPoolerJO SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    private SpawnerJO spawner;

    private void Awake() {
        SharedInstance = this;
        spawner = GetComponent<SpawnerJO>();
        amountToPool = spawner.numberOfObjects();
    }

    private void Start() {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++) {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false); 
            pooledObjects.Add(obj);
        }
    }
    
    public GameObject GetPooledObject() {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }
        
        return null;
    }
}
