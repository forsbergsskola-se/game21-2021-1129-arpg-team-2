using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pool", fileName = "GameObjectPool")]
public class PoolScriptableObject : ScriptableObject
{
    public Stack<GameObject> pool;
    private int size;
    private GameObject prefab;
    

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
        pool = new Stack<GameObject>();
        for (int i = 0; i < size; i++)
        {
            var temp = Instantiate(prefab);
            temp.SetActive(false);
            pool.Push(temp);
        }
    }
}
