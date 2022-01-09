using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : MonoBehaviour, IAttack
{
    [SerializeField] private Weapon magicOrb;
    private GameObject source;

    public void SetUp(GameObject source) {
        this.source = source;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == source) {
            return;
        }
        
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
        thisTarget?.TakeDamage(magicOrb.Power);
    }
}
