using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SorceressAI : MonoBehaviour
{
//Layers
    [Header("Assign Layers")]
    public LayerMask PlayerLayer;
    public LayerMask GroundLayer;
   
    //Patrolling
    [Header("Patrolling")]
    [SerializeField] private bool isPatrolling;
    [SerializeField] private float patrolSpeed = 4f;
    [SerializeField] float walkPointRange = 10f;
    private Vector3 walkPoint;
    private bool walkPointSet;

    //Chasing
    [Header("Chasing")]
    [SerializeField] private float chaseSpeed = 10f;

    [Header("Range")] 
    [SerializeField] private float awarenessRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float hearingRange;
    
    //States
    private Vector3 targetDir;
    private float angleToPlayer;
    private bool playerInAwarenessRange, playerInAttackRange, playerInSight, playerInHearingRange;
    private bool noObstacle;
    private bool isInPatrolState;
    private bool isStartPositionReset; 
    
    //Player Defeat
    [Header("Player Defeat")]
    [SerializeField] private float breathingTimeAfterDefeating = 7f;

    //Player and Enemy position- Navmesh
    [Header("Angle")]
    [SerializeField] private float fieldOfViewAngle = 90f;
    
    [Header("Assign the player's position")]
    [SerializeField] private Vector3Value playerPosition;
    private UnityEngine.AI.NavMeshAgent agent;
    private Vector3 startPosition;
    private bool playerIsDefeated;
    private EntityAttack entityAttack;

    //Animatior controller
    private Animator sorceressAnimator;

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        startPosition = agent.transform.position;
        agent.isStopped = false;
        isInPatrolState = true;
        playerIsDefeated = false;
        entityAttack = GetComponent<EntityAttack>();
        sorceressAnimator = GetComponent<Animator>();
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
                sorceressAnimator.SetBool("isWalking", true);
            }
            else
            {
                noObstacle = false;
                agent.isStopped = true;
                sorceressAnimator.SetBool("isWalking", false);
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
               sorceressAnimator.SetBool("isWalking", isInPatrolState);
            }
            else if (!isStartPositionReset)
            { 
                //agent.ResetPath();
                agent.isStopped = false;
                agent.SetDestination(startPosition);
                isStartPositionReset = true;
                sorceressAnimator.SetBool("isWalking", true);
            }
        }
        
        // Conditions for calling patrol, chase and attack methods
        if (isPatrolling && isInPatrolState) Patrolling();
        if (((playerInAwarenessRange && playerInSight) || playerInHearingRange)  && !playerInAttackRange && noObstacle && !playerIsDefeated) ChasePlayer();
        if (((playerInAwarenessRange && playerInSight) || playerInHearingRange)  && playerInAttackRange && noObstacle && !playerIsDefeated) AttackPosition();
    }

    private void Patrolling()
    {
        isInPatrolState = true;
        sorceressAnimator.SetBool("isWalking", isInPatrolState);
        agent.speed = patrolSpeed;
        
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            agent.isStopped = false;
            sorceressAnimator.SetBool("isWalking", true);
        }
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 5f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, GroundLayer))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.speed = chaseSpeed;
        agent.SetDestination(playerPosition.Vector3);
        agent.isStopped = false;
        isInPatrolState = false;
        sorceressAnimator.SetBool("isWalking", true);
        isStartPositionReset = false;
    }

    private void AttackPosition()
    {
        agent.speed = chaseSpeed;
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(playerPosition.Vector3);

        agent.isStopped = true;
        isInPatrolState = false;
        sorceressAnimator.SetBool("isWalking", isInPatrolState);
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

    public void OnPlayerDefeated()
    {
        playerIsDefeated = true;
        entityAttack.enabled = false;
        
        if (isPatrolling)
        {
            isInPatrolState = true;
            sorceressAnimator.SetBool("isWalking", isInPatrolState);
        }
        else
        {
            agent.SetDestination(startPosition);
        }

    }
    
    public void OnPlayerNotDefeated()
    {
        StartCoroutine(TestCoroutine());
    }

    private IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(breathingTimeAfterDefeating);
        playerIsDefeated = false;
        entityAttack.enabled = true;
    }
}
