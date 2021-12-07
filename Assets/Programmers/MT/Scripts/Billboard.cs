using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

  
    void LateUpdate()
    {    //keeps the HealthBar looking at the camera
        transform.LookAt(transform.position + cam.forward);
    }
}
