using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class EnemyPooler : MonoBehaviour
{
    private int amountToPool;
    private List<Enemy> pooledObjects = new List<Enemy>();

    public void Setup(int poolSize, Enemy prefab)
    {
        amountToPool = poolSize;
        
        for (int i = 0; i < amountToPool; i++)
        {
            var obj = Instantiate(prefab);
            obj.gameObject.SetActive(false); 
            pooledObjects.Add(obj);
        }
    }

    public Enemy GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].gameObject.activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        
        return null;
    }
}
