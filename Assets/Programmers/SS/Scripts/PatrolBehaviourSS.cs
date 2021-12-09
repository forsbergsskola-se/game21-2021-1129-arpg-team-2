using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviourSS : StateMachineBehaviour
{
    private List<Transform> patrolPoints=new List<Transform>();
    public float patrolSpeed;
    private int randomSpot;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (Transform patrolPoint in patrolPoints)
        {
            patrolPoint.position = GameObject.FindGameObjectWithTag("Patrol").transform.position;
            patrolPoint.rotation = GameObject.FindGameObjectWithTag("Patrol").transform.rotation;
        }
        randomSpot = Random.Range(0, patrolPoints.Count);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isPatrolling", false);
        }

        if (Vector3.Distance(animator.transform.position, patrolPoints[randomSpot].position)>0.2f)
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, patrolPoints[randomSpot].position, patrolSpeed * Time.deltaTime);
        }
        else
        {
            randomSpot= Random.Range(0, patrolPoints.Count);
        }
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
