using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorContollerMT : MonoBehaviour
{
    private Animator doorAnim;

    private void OnTriggerEnter(Collider other)
    {
        doorAnim.SetBool("isOpening", true);
    }


    private void OnTriggerExit(Collider other)
    {
        doorAnim.SetBool("isOpening", false);
    }

    void Start()
    {
        doorAnim = this.transform.parent.GetComponent<Animator>();
    }

    
  
}
