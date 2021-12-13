﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackBehaviourSS : StateMachineBehaviour
{

    private NavMeshAgent agent;
    [Header("Assign the player's position")]
    [SerializeField] private Vector3Value playerPosition;
    private Vector3 targetDir;
    private float angleToPlayer;
    [Header("Angle")]
    [SerializeField] private float fieldOfViewAngle = 90f;
    [Header("Range")]
    [SerializeField] private float awarenessRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float hearingRange;
    //Layers
    [Header("Assign Layers")]
    public LayerMask PlayerLayer;
    public LayerMask GroundLayer;

    //Patrolling
    [Header("Patrolling")]
    [SerializeField] private float patrolSpeed = 4f;
    [SerializeField] float walkPointRange = 10f;
    private Vector3 walkPoint;
    private bool walkPointSet;

    //Temporary bools
    bool playerInSight;
    private bool noObstacle;
    bool playerInAwarenessRange;
    bool playerInAttackRange;
    bool playerInHearingRange;
    bool playerIsDefeated;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        //Move to chasing state
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("isChasing");
        }

    }

    private void Patrolling(Transform thisTransform)
    {
        agent.speed = patrolSpeed;

        if (!walkPointSet) SearchWalkPoint(thisTransform);

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            agent.isStopped = false;
        }

        Vector3 distanceToWalkPoint = thisTransform.position - walkPoint;
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 2f)
            walkPointSet = false;
    }
    private void SearchWalkPoint(Transform thisTransform)
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(thisTransform.position.x + randomX, thisTransform.position.y, thisTransform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -thisTransform.up, 2f, GroundLayer))
            walkPointSet = true;
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
