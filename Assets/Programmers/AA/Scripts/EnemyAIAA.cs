using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyAIAA : MonoBehaviour
{
    //Layers
    public LayerMask PlayerLayer, GroundLayer;
   
    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField]private bool isPatrolling;
    public float walkPointRange;
    [SerializeField] private float patrolSpeed = 4f;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public Vector3 targetDir;
    public float awarenessRange, attackRange, angleToPlayer, hearingRange;
    public bool playerInAwarenessRange, playerInAttackRange, playerInSight, playerInHearingRange;
    public bool noObstacle;
    public bool isInPatrolState;
    public bool isStartPositionReset;
    [SerializeField] private float chaseSpeed = 10f;

    //Player and Enemy position- Navmesh
    [SerializeField] private float fieldOfViewAngle = 90;
    [SerializeField] private Vector3Value playerPosition;
    private NavMeshAgent agent;
    private Vector3 startPosition;
    
    
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPosition = agent.transform.position;
        Debug.Log(startPosition);
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
        RaycastHit hit;
        //Check for obstacle
        //noObstacle = Physics.Raycast(transform.position, targetDir, awarenessRange, GroundLayer);
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


        //Debug.Log("Raycast hits: "+ hit.transform.name);
        
        
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
            else
            {
                if (!isStartPositionReset)
                {
                    //agent.ResetPath();
                    agent.isStopped = false;
                    agent.SetDestination(startPosition);
                    isStartPositionReset = true;
                    Debug.Log("Going to the start "+startPosition);
                }
                
            }
        }
        
        if (isPatrolling && isInPatrolState)
        {
            Patrolling();
        }
        if (((playerInAwarenessRange && playerInSight) || playerInHearingRange)  && !playerInAttackRange && noObstacle) ChasePlayer();
        if (((playerInAwarenessRange && playerInSight) || playerInHearingRange)  && playerInAttackRange && noObstacle) AttackPlayer();
    }

    private void Patrolling()
    {
        isInPatrolState = true;
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            agent.isStopped = false;
        }
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        agent.speed = patrolSpeed;
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
        Debug.Log("Enemy found the player!");
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