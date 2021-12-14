using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDropAA : MonoBehaviour
{
    public GameObject coinPrefab;
    // Start is called before the first frame update

    public void DropCoin()
    {
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }
}
