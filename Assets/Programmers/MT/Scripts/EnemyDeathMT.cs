using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyDeathMT : MonoBehaviour
{
    public static event Action enemyDeath;

    private void OnDisable()
    {
        enemyDeath?.Invoke();
    }
}
