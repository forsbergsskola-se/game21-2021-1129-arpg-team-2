using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiactiveBookIcon : MonoBehaviour
{
    public GameObject bookIcon;
    public LayerMask PlayerLayer;
    [SerializeField] private float intractionRange = 10f;
    private bool isInIntractRange;
   
    
    void Update()
    {
        isInIntractRange = Physics.CheckSphere(transform.position, intractionRange, PlayerLayer);

        bookIcon.SetActive(isInIntractRange);
    }
}
