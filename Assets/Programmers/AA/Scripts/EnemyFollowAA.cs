using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyFollowAA : MonoBehaviour
{
    [SerializeField] private Vector3Value enemyPosition;
    public NavMeshAgent enemy;

    [FormerlySerializedAs("Player")] public Transform player;

    private void Awake()
    {
        enemyPosition.Vector3 = transform.position;
    }

    void Update()
    {
        enemy.SetDestination(player.position);
        enemyPosition.Vector3 = transform.position;
    }
}
