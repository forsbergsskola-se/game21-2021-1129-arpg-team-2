using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviourSS : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Transform playerPos;
    [Header("Assign the player's position")]
    [SerializeField] private Vector3Value playerPosition;
    public float chaseSpeed;
    private bool playerInAwarenessRange;
    private bool playerInAttackRange;
    [Header("Range")]
    [SerializeField] private float attackRange;
    [SerializeField] private float awarenessRange;
    [Header("Assign Layers")]
    public LayerMask PlayerLayer;
    private Vector3 targetDir;
    private bool noObstacle;
    private EntityAttack entityAttack;
    private bool playerIsDefeated;
    private float breathingTimeAfterDefeating;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        entityAttack = animator.GetComponent<EntityAttack>();
        agent = animator.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerPos =GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        targetDir = playerPosition.Vector3 - animator.transform.position;
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

        playerInAwarenessRange = Physics.CheckSphere(animator.transform.position, awarenessRange, PlayerLayer);
        playerInAttackRange = Physics.CheckSphere(animator.transform.position, attackRange, PlayerLayer);
        agent.speed = chaseSpeed;
        agent.SetDestination(playerPosition.Vector3);
        agent.isStopped = false;
        if(playerInAttackRange && noObstacle && !playerIsDefeated)
        {

            animator.SetTrigger("isAttacking");
        }
        if (!playerInAwarenessRange || !noObstacle || playerIsDefeated)
        {
            animator.SetTrigger("isPatrolling");
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

    private IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(breathingTimeAfterDefeating);
        playerIsDefeated = false;
        entityAttack.enabled = true;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(agent.gameObject.transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(agent.gameObject.transform.position, awarenessRange);
        //Gizmos.color = Color.magenta;
        //Gizmos.DrawWireSphere(agent.gameObject.transform.position, hearingRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(agent.gameObject.transform.position, targetDir);
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
