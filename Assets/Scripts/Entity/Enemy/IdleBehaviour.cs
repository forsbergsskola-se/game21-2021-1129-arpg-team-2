using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleBehaviour : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Vector3 startPosition;
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
    [Header("Check to patrol")]
    [SerializeField] private bool isEnemyPatroling;

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
        agent = animator.gameObject.GetComponent<NavMeshAgent>();
        startPosition = agent.transform.position;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Check for the angle of view
        targetDir = playerPosition.Vector3 - animator.transform.position;
        angleToPlayer = (Vector3.Angle(targetDir, animator.transform.forward));
        if (angleToPlayer >= -fieldOfViewAngle && angleToPlayer <= fieldOfViewAngle && noObstacle && playerInAwarenessRange) // 180� FOV
        {
            playerInSight = true;
        }
        else
        {
            playerInSight = false;
        }


        //Check for obstacle
        RaycastHit hit;
        if (Physics.Raycast(animator.transform.position, targetDir, out hit))
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
        playerInAwarenessRange = Physics.CheckSphere(animator.transform.position, awarenessRange, PlayerLayer);
        playerInAttackRange = Physics.CheckSphere(animator.transform.position, attackRange, PlayerLayer);
        playerInHearingRange = Physics.CheckSphere(animator.transform.position, hearingRange, PlayerLayer);

        //Moving to chase state
        if (((playerInAwarenessRange && playerInSight) || playerInHearingRange) && !playerInAttackRange && noObstacle && !playerIsDefeated)
        {
            animator.SetTrigger("isChasing");
        }


        if(isEnemyPatroling)
        {
            animator.SetTrigger("isPatrolling");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(agent.gameObject.transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(agent.gameObject.transform.position, awarenessRange);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(agent.gameObject.transform.position, hearingRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(agent.gameObject.transform.position, targetDir);
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
