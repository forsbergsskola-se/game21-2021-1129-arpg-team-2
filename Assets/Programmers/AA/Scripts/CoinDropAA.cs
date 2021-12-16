using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinDropAA : MonoBehaviour
{
    public GameObject coinPrefab;

    [SerializeField] private int maxCoinsDrop = 5; 
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, 1.32f, 0);
    }
    

    public void DropCoin(Transform transform)
    {
        int randomNum = Random.Range(1, maxCoinsDrop +1);
        for (var i = 0; i < randomNum; i++)
        {
            Instantiate(coinPrefab, transform.position+offset, Quaternion.identity);
        }
    }
    public void DropCoin()
    {
        int randomNum = Random.Range(1, maxCoinsDrop +1);
        for (var i = 0; i < randomNum; i++)
        {
            Instantiate(coinPrefab, transform.position+offset, Quaternion.identity);
        }
    }
}
