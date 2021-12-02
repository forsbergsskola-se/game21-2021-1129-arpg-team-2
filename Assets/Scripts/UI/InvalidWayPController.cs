using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvalidWayPController : MonoBehaviour
{
    private void Update()
    {
        Invoke(nameof(DestroyObject), 0.5f);
        if (Input.GetMouseButtonDown(0))
        {
            DestroyObject();
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
