using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    
    public LayerMask PlayerLayer;
    public GameObject interactionBox;
    [SerializeField] private float intractionRange = 15f;
    private bool isInIntractRange;
   
    
    void Update()
    {
        isInIntractRange = Physics.CheckSphere(transform.position, intractionRange, PlayerLayer);

        interactionBox.SetActive(isInIntractRange);
    }
}
