using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvalidWaypointController : MonoBehaviour
{
    void Update()
    {
        Invoke(nameof(DestroyObject), 0.5f);
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }
    
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
