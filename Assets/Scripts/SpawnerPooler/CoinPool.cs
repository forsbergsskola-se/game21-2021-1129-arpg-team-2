
using System;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private PoolScriptableObject pool;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int size;
    private void Awake()
    {
        pool.Prefab = objectToPool;
        pool.Size = size;
        pool.Load();
    }

    private void Update()
    {

    }
}
