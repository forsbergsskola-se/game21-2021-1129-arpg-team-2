using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerJO : MonoBehaviour {
    [SerializeField] private GameObject objectToPool;
    private int amountToPool;
    private List<GameObject> pooledObjects = new List<GameObject>();
    private SpawnerJO spawner;

    public void Setup(SpawnerJO spawnerJo, int poolSize) {
        spawner = spawnerJo;
        amountToPool = poolSize;
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
