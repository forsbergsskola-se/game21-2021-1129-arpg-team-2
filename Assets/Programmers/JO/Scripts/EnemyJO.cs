using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EnemyJO : MonoBehaviour
{
    public Action<EnemyJO> OnDeath;
    [SerializeField] private FloatValue currentHealth;
    private float health;
    
    public int SpawnIndex { get; private set; }
    public FloatValue CurrentHealth { get => currentHealth; set => currentHealth = value; }

    public void Spawn(int index, SpawnPoint spawnPoint)
    {
        SpawnIndex = index;
        transform.position = spawnPoint.transform.position;
        transform.rotation = Quaternion.identity;
        health = currentHealth.InitialValue;
        gameObject.SetActive(true);
        StartCoroutine(TestKill());
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            gameObject.SetActive(false);
            OnDeath?.Invoke(this);
        }
    }

    private IEnumerator TestKill()
    {
        while (currentHealth.RuntimeValue > 0f)
        {
            TakeDamage(Random.Range(1f,5f));
            yield return new WaitForSeconds(2);
        }
    }
}
