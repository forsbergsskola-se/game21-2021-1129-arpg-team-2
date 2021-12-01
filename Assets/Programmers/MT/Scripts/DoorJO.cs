using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorJO : MonoBehaviour
{
    private Animator doorAnimation;
    private void Start()
    {
        doorAnimation = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        doorAnimation.SetBool("isOpening", true);
    }
}
