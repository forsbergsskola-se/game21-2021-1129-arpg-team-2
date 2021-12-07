using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Action<Enemy> OnDeath;
    public int SpawnIndex { get; private set; }

    public void Spawn(int index, SpawnPoint spawnPoint)
    {
        SpawnIndex = index;
        transform.position = spawnPoint.transform.position;
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(true);
    }

    public void OnEnemyDeath()
    {
        gameObject.SetActive(false);
        OnDeath?.Invoke(this);
    }
}
