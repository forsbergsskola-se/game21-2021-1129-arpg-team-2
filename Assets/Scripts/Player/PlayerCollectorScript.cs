using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectorScript : MonoBehaviour
{
    [SerializeField] private AudioSource coinCollect;
    [SerializeField] private IntegerValue playersCoins;
    
    void Start()
    {
        //coinCollect = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Coin"))
        {
            CoinCounterAA.coinAmount += 1;
            playersCoins.Int = CoinCounterAA.coinAmount;
            coinCollect.Play();
        }
    }
}
