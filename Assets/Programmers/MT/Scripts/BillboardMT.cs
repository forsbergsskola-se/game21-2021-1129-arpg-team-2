using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardMT : MonoBehaviour
{
    public Transform cam;
    
    [SerializeField] private Transform targetPosiotion;

    public Vector3 offset;
    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;

        // targetPosiotion = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void LateUpdate()
    {    
        transform.LookAt(transform.position + cam.forward);

        transform.position = targetPosiotion.position + offset;
    }
}
