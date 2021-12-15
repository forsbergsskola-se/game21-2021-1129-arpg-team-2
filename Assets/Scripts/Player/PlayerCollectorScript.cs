using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectorScript : MonoBehaviour
{
    [SerializeField] private AudioSource coinCollect;
    
    void Start()
    {
        //coinCollect = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Coin"))
        {
            CoinCounterAA.coinAmount += 1;
            coinCollect.Play();
        }
    }
}
