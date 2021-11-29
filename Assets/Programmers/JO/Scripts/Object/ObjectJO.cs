using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectJO : MonoBehaviour, IDamageableJO
{
    [SerializeField] IntegerValue objectHealth;

    void IDamageableJO.TakeDamage(int WeaponDamage) {
        objectHealth.Int -= WeaponDamage;
    }
}
