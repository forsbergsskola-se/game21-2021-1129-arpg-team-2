using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Enemy coinPrefab;
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private IntegerValue playersCoins;
    private Pooler<CoinScript> coinPool;
    private int coinCollectedCount;

    private void Start()
    {
        coinPool = new Pooler<CoinScript>();
        
        SpawnFromPool();
        
    }
    private void SpawnFromPool()
    {
        CoinScript coin = coinPool.GetPooledObject(); 
        if (coin != null)
        {
            coin.Spawn();
            if ( coin.coinIsCollected )
            {
                CoinIsCollected(coin);
            }
        }
    }

    private void CoinIsCollected(CoinScript coin)
    {
        collectSound.Play();
        playersCoins.Int += 10;
        coinPool.Return(coin);
    }
}
