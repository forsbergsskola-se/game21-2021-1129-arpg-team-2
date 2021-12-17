using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public bool coinIsCollected;
    public void Spawn()
    {
        transform.position = this.transform.position;
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(true);
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
