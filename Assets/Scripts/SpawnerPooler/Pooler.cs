using System.Collections.Generic;
using UnityEngine;

public class Pooler<T> where T : MonoBehaviour
{
    private int amountToPool;
    private Stack<T> pooledObjects = new Stack<T>();

    public void Setup(int poolSize, T prefab)
    {
        amountToPool = poolSize;
        
        for (int i = 0; i < amountToPool; i++)
        {
            var obj = Object.Instantiate(prefab);
            obj.gameObject.SetActive(false); 
            pooledObjects.Push(obj);
        }
    }

    public T GetPooledObject() {
        return pooledObjects.Pop();
    }

    public void Return(T t) {
        pooledObjects.Push(t);
    }
}