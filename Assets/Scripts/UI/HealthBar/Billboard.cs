using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // public Transform cam;
    public Transform cam;

    public Transform rat;
    private Vector3 offset;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        offset = new Vector3(0, 2f, 0);
    }

    void LateUpdate()
    {    //keeps the HealthBar looking at the camera
        transform.LookAt(transform.position + cam.forward);
        
        
        // transform.LookAt(transform.position + cam.transform.rotation * Vector3.back, cam.transform.rotation * Vector3.up);
        
        // transform.LookAt(transform.position + Camera.main.transform.rotation *- Vector3.back,
        //     Camera.main.transform.rotation *- Vector3.down);
        
        // transform.LookAt(cam);
        //transform.position = rat.position + offset;
    }

    public void KillBar()
    {
        Destroy(gameObject);
    }
}
