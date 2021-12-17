using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private int maxCoinsDrop = 5;
    [SerializeField] private PoolScriptableObject coinPool;
    private int coinCollectedCount;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, 1.32f, 0);
    }
    public void SpawnFromPool()
    {
        int randomNum = Random.Range(1, maxCoinsDrop +1);
        for (var i = 0; i < randomNum; i++)
        {
            if (coinPool != null)
            {
                Debug.Log("There is a pool!");
                var tempCoin = coinPool.pool.Pop();
                tempCoin.SetActive(true);
                tempCoin.transform.position = this.transform.position + offset;
                if ( tempCoin.GetComponent<CoinScript>().coinIsCollected )
                {
                    CoinIsCollected(tempCoin);
                }
            }
        }
    }

    private void CoinIsCollected(GameObject coin)
    {
        coinPool.pool.Push(coin);
    }
}
