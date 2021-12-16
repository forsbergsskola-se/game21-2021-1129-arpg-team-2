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
        playersCoins.Int = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Coin"))
        {
            playersCoins.Int += 1;
            coinCollect.Play();
        }
    }
}
