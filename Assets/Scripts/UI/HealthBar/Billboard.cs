using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void LateUpdate()
    {    //keeps the HealthBar looking at the camera
        transform.LookAt(transform.position + cam.forward);
    }
}
