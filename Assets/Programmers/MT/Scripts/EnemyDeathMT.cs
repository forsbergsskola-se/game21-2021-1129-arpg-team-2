using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyDeath : MonoBehaviour
{
    public static event Action deathCounter;

    private void OnDisable()
    {
        deathCounter?.Invoke();
    }
}
