using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackBehaviour : StateMachineBehaviour
{
    private NavMeshAgent agent;
    [Header("Assign the player's position")]
    [SerializeField] private Vector3Value playerPosition;
    public float chaseSpeed;
    private Vector3 targetDir;
    [Header("Range")]
    [SerializeField] private float attackRange;
    private EntityAttack entityAttack;
    //Layers
    [Header("Assign Layers")]
    public LayerMask PlayerLayer;
    public LayerMask GroundLayer;

    //Temporary bools
    private bool noObstacle;
    bool playerInAttackRange;
    bool playerIsDefeated;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        entityAttack= animator.GetComponent<EntityAttack>();
        agent = animator.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Check for the angle of view
        targetDir = playerPosition.Vector3 - animator.transform.position;
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
        playerInAttackRange = Physics.CheckSphere(animator.transform.position, attackRange, PlayerLayer);

        //Move to the chase state
        agent.speed = chaseSpeed;
        //Make sure enemy doesn't move
        agent.SetDestination(animator.transform.position);
        animator.transform.LookAt(playerPosition.Vector3);
        agent.isStopped = true;

        if (!playerInAttackRange || !noObstacle )
        {
            animator.SetTrigger("isChasing");
        }
    }

    public void OnPlayerDefeated()
    {
        playerIsDefeated = true;
        entityAttack.enabled = false;
    }

    public void OnPlayerNotDefeated()
    {
        //StartCoroutine(TestCoroutine());
        playerIsDefeated = false;
        entityAttack.enabled = true;
    }

    
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //
    //}

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
