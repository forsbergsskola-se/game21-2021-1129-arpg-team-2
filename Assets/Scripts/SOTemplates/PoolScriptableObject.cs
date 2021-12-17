using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pool", fileName = "GameObjectPool")]
public class PoolScriptableObject : ScriptableObject
{
    private Stack<GameObject> pool;
    private int size;
    private GameObject prefab;
    
    public Stack<GameObject> Pool => pool;

    public int Size
    {
        get => size; 
        set => size = value;
    }

    public GameObject Prefab
    {
        set => prefab = value;
    }
    
    public void Load()
    {
        for (int i = 0; i < size; i++)
        {
            var temp = Instantiate(prefab);
            temp.SetActive(false);
        }
    }
    
    public void Add(GameObject objectToAdd)
    {
        pool.Push(objectToAdd);
    }

    public GameObject Pop()
    {
        return pool.Pop();
    }
}
