using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvalidWaypointController : MonoBehaviour
{
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
        else
        {
            Invoke(nameof(DestroyObject), 0.5f);
        }
        
        
    }
    
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
