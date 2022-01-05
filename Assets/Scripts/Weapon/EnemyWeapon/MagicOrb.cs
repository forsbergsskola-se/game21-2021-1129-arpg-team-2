using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : MonoBehaviour, IAttack
{
    [SerializeField] private float damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IDamageable>() != null)
        {
            IDamageable target = other.gameObject.GetComponent<IDamageable>();
            Attack(target);
        }
        
        Destroy(this.gameObject);
    }

    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    public void Attack(IDamageable thisTarget)
    {
        //attackSound.Play();
        thisTarget?.TakeDamage(damage);
    }
}
