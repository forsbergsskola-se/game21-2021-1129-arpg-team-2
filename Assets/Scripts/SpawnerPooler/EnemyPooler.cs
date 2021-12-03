using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class EnemyPooler : MonoBehaviour
{
    private int amountToPool;
    private List<EnemyJO> pooledObjects = new List<EnemyJO>(); //Everywhere it says EnemyJO needs to be Enemy

    public void Setup(int poolSize, EnemyJO prefab)
    {
        amountToPool = poolSize;
        
        for (int i = 0; i < amountToPool; i++)
        {
            var obj = Instantiate(prefab);
            obj.gameObject.SetActive(false); 
            pooledObjects.Add(obj);
        }
    }

    public EnemyJO GetPooledObject()
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
