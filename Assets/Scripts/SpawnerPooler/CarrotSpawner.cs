using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarrotSpawner : MonoBehaviour
{
    [SerializeField] private int maxCarrotDrop = 5;
    [SerializeField] private PoolScriptableObject carrotPool;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, 1.32f, 0);
    }
    public void SpawnFromPool()
    {
        int randomNum = Random.Range(1, maxCarrotDrop +1);
        for (var i = 0; i < randomNum; i++)
        {
            if (carrotPool != null)
            {
                var tempCarrot = carrotPool.pool.Pop();
                tempCarrot.SetActive(true);
                tempCarrot.transform.position = this.transform.position + offset;
                if ( tempCarrot.GetComponent<CoinScript>().coinIsCollected )
                {
                    CarrotIsCollected(tempCarrot);
                }
            }
        }
    }

    private void CarrotIsCollected(GameObject carrot)
    {
        carrotPool.pool.Push(carrot);
    }
}