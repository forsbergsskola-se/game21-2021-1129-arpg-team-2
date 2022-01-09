using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerScript : MonoBehaviour
{
    public LayerMask PlayerLayer;
    [SerializeField] private BooleanValue isFlowerCollected;
    [SerializeField] private float intractionRange = 10f;
    private bool isInIntractRange;
    
    void Update()
    {
        isInIntractRange = Physics.CheckSphere(transform.position, intractionRange, PlayerLayer);

        if (isInIntractRange && Input.GetKey(KeyCode.F))
        {
            isFlowerCollected.BoolValue = true;
        }
        
    }
}
