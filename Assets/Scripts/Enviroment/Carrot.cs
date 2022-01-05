using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public void Spawn(Vector3 spawnPosition)
    {
        gameObject.SetActive(true);
        transform.position = spawnPosition;
        transform.rotation = Quaternion.identity;
    }
}
