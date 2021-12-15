using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CoinDropAA : MonoBehaviour
{
    public GameObject coinPrefab;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, 1.32f, 0);
    }

    public void DropCoin(Transform transform)
    {
        Instantiate(coinPrefab, transform.position+offset, Quaternion.identity);
    }
    public void DropCoin()
    {
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }
}
