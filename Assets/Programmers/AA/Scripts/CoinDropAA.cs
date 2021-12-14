using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDropAA : MonoBehaviour
{
    public GameObject coinPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DropCoin()
    {
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }
}
