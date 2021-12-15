using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinScriptAA : MonoBehaviour
{
    [SerializeField] private AudioSource coinCollect;
    
    void Start()
    {
        coinCollect = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            CoinCounterAA.coinAmount += 1;
            coinCollect.Play();
            Destroy(gameObject);
        }
    }
}
