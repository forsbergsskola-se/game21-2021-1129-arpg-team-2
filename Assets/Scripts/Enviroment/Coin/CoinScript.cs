using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public bool coinIsCollected;

    public void Spawn(Vector3 spawnPosition)
    {
        gameObject.SetActive(true);
        transform.position = spawnPosition;
        transform.rotation = Quaternion.identity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            coinIsCollected = true;
            gameObject.SetActive(false);
        }
    }
}
