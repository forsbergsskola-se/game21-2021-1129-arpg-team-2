using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorJO : MonoBehaviour
{
    [SerializeField] private IntegerValue OpenDistance;
    
    private Animator doorAnimation;
    private void Start()
    {
        doorAnimation = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
            
        if (Vector3.Distance(transform.position, player.transform.position) <= OpenDistance.Int)
        {
            doorAnimation.SetBool("isOpening", true);
        }
        
    }
}
