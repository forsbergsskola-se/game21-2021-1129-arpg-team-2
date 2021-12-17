using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinScript coinPrefab;
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private IntegerValue playersCoins;
    [SerializeField] private int maxCoinsDrop = 5;
    private Pooler<CoinScript> coinPool;
    private int coinCollectedCount;
    private Vector3 spawnPosition;
    private Vector3 offset;

    private void Start()
    {
        spawnPosition = transform.position;
        offset = new Vector3(0, 1.32f, 0);
        
        coinPool = new Pooler<CoinScript>();
        coinPool.Setup(30,coinPrefab);
        
        int randomNum = Random.Range(1, maxCoinsDrop +1);
        for (var i = 0; i < randomNum; i++)
            SpawnFromPool();
        
    }
    private void SpawnFromPool()
    {
        CoinScript coin = coinPool.GetPooledObject(); 
        if (coin != null)
        {
            coin.Spawn(spawnPosition + offset);
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
