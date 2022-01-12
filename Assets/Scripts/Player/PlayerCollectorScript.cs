using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectorScript : MonoBehaviour
{
    [SerializeField] private AudioSource coinCollect;
    [SerializeField] private IntegerValue playersCoins;
    [SerializeField] private int coinValue = 10;
    
    void Start()
    {
        playersCoins.Int = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Coin"))
        {
            playersCoins.Int += coinValue;
            coinCollect.Play();
        }
    }
}
