using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour, IDamageable
{
    public Action<Enemy> OnDeath; //Important
    [SerializeField] private FloatValue currentHealth;
    private float health;
    
    public int SpawnIndex { get; private set; } //Important
    public FloatValue CurrentHealth { get => currentHealth; set => currentHealth = value; }

    public void Spawn(int index, SpawnPoint spawnPoint) //Important
    {
        SpawnIndex = index;
        transform.position = spawnPoint.transform.position;
        transform.rotation = Quaternion.identity;
        health = currentHealth.InitialValue;
        gameObject.SetActive(true);
        StartCoroutine(TestKill()); //Not important only for testing
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth.RuntimeValue -= damage;

        Debug.Log("Enemy takes damage: " + CurrentHealth.RuntimeValue);
        // health -= damage;
        if (CurrentHealth.RuntimeValue <= 0f)
        {
            gameObject.SetActive(false); //Important happen on death
            OnDeath?.Invoke(this); //Important happen on death
        }
    }

    private IEnumerator TestKill() //Remove, only used for testing
    {
        while (currentHealth.RuntimeValue > 0f)
        {
            TakeDamage(Random.Range(1f,5f));
            yield return new WaitForSeconds(2);
        }
    }
}
