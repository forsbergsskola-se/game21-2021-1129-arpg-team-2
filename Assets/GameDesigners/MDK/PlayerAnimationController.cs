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
        else
        {
            animator.SetBool("Is Running", false);
        }
    }
    public void OnPlayerAttack()
    {
        animator.SetBool("Is attacking", true);
    }
    public void OnPlayerAttackStop()
    {
        animator.SetBool("Is attacking", false);
    }
}
