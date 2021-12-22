using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
   
    Animator animator;
    private Vector3 previousPosition;
    public float currentSpeed;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        Vector3 currentMove = transform.position - previousPosition;
        currentSpeed = currentMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;
        if (currentSpeed >= 4)
        {
            animator.SetBool("Is Running", true);
        }
      /*  else if (currentSpeed >0 && currentSpeed < 7)
        {
            animator.SetBool("Is Walking", true);
        }
      */
        else
        {
            animator.SetBool("Is Running", false);
           // animator.SetBool("Is Walking", false);
        }
    }
}
