using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyAIAA : MonoBehaviour
{
    [Header("Assign Layer")]
    //Layers
    public LayerMask PlayerLayer, GroundLayer;
   
    //Patrolling
    [SerializeField] private bool isPatrolling;
    [SerializeField] private float patrolSpeed = 4f;
    [SerializeField] float walkPointRange = 10f;
    private Vector3 walkPoint;
    private bool walkPointSet;
    

    //Attacking
    private float timeBetweenAttacks;
    private bool alreadyAttacked;

    //States
    [SerializeField] private float chaseSpeed = 10f;
    [SerializeField] private float awarenessRange, attackRange, hearingRange;
    private Vector3 targetDir;
    private float angleToPlayer;
    private bool playerInAwarenessRange, playerInAttackRange, playerInSight, playerInHearingRange;
    private bool noObstacle;
    private bool isInPatrolState;
    private bool isStartPositionReset; 
    
    //Player and Enemy position- Navmesh
    [SerializeField] private float fieldOfViewAngle = 90f;
    [SerializeField] private Vector3Value playerPosition;
    private NavMeshAgent agent;
    private Vector3 startPosition;
    
    
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPosition = agent.transform.position;
        agent.isStopped = false;
        isInPatrolState = true;
    }
    
    private void Update()
    {
        //Check for the angle of view
        targetDir = playerPosition.Vector3 - transform.position;
        angleToPlayer = (Vector3.Angle(targetDir, transform.forward));
        if (angleToPlayer >= -fieldOfViewAngle && angleToPlayer <= fieldOfViewAngle && noObstacle && playerInAwarenessRange) // 180° FOV
            playerInSight = true;
        else
        {
            playerInSight = false;
        }
        
        //Check for obstacle
        RaycastHit hit;
        if (Physics.Raycast(transform.position, targetDir, out hit))
        {
            if (hit.transform.CompareTag("Player"))
            {
                noObstacle = true;
                agent.isStopped = false;
            }
            else
            {
                noObstacle = false;
                agent.isStopped = true;
            }
        }
        
        //Check for sight, hearing and attack range
        playerInAwarenessRange = Physics.CheckSphere(transform.position, awarenessRange, PlayerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, PlayerLayer);
        playerInHearingRange = Physics.CheckSphere(transform.position, hearingRange, PlayerLayer);

        if (!playerInAwarenessRange)
        {
            if (isPatrolling)
            {
               isInPatrolState = true; 
            }
            else if (!isStartPositionReset)
            { 
                //agent.ResetPath();
                agent.isStopped = false;
                agent.SetDestination(startPosition);
                isStartPositionReset = true;
            }
        }
        
        // Conditions for calling patrol, chase and attack methods
        if (isPatrolling && isInPatrolState) Patrolling();
        if (((playerInAwarenessRange && playerInSight) || playerInHearingRange)  && !playerInAttackRange && noObstacle) ChasePlayer();
        if (((playerInAwarenessRange && playerInSight) || playerInHearingRange)  && playerInAttackRange && noObstacle) AttackPlayer();
    }

    private void Patrolling()
    {
        isInPatrolState = true;
        agent.speed = patrolSpeed;
        
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            agent.isStopped = false;
        }
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 2f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, GroundLayer))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.speed = chaseSpeed;
        agent.SetDestination(playerPosition.Vector3);
        agent.isStopped = false;
        isInPatrolState = false;
        isStartPositionReset = false;
    }

    private void AttackPlayer()
    {
        agent.speed = chaseSpeed;
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(playerPosition.Vector3);

        agent.isStopped = true;
        isInPatrolState = false;
        
        if (!alreadyAttacked)
        {
            Debug.Log("Attack");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, awarenessRange);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, hearingRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, targetDir);
    }
}