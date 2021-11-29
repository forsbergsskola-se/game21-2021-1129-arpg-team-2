using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectJO : MonoBehaviour, IDamageableJO
{
    [SerializeField] IntegerValue objectHealth;
    static int weaponDam = 10;

    public void TakeDamage(int WeaponDamage) {
        objectHealth.Int -= WeaponDamage;
    }
}
