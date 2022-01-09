using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinScript : MonoBehaviour
{
    public LayerMask PlayerLayer;
    [SerializeField] private float intractionRange = 10f;
    [SerializeField] private BooleanValue isCoffinOpen;
    private bool isInIntractRange;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isInIntractRange = Physics.CheckSphere(transform.position, intractionRange, PlayerLayer);

        if (isInIntractRange && Input.GetKey(KeyCode.F))
        {
            _animator.SetBool("CoffinOpen", true);
            isCoffinOpen.BoolValue = true;
        }
    }
}
