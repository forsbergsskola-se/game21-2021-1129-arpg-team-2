using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectJO : MonoBehaviour, IDamageableJO
{
    [SerializeField] IntegerValue objectHealth;
    static int weaponDam = 10;

    void IDamageableJO.TakeDamage(int WeaponDamage) {
        objectHealth.Int -= WeaponDamage;
    }

    void main() {
        //IDamageableJO.TakeDamage(weaponDam);
    }
}
