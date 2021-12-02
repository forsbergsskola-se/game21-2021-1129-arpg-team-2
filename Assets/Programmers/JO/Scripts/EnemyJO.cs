using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJO : MonoBehaviour, IDamageable
{
    public FloatValue CurrentHealth { get; set; }
    public void TakeDamage(FloatValue damage) {
        throw new System.NotImplementedException();
    }
}
