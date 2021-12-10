using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FloatingText : MonoBehaviour
{
  public float destroyTime = 2f;

  public Vector3 Offset = new Vector3(0, 3, 0); 

  private void Start()
  {
    Destroy(gameObject, destroyTime);

    transform.localPosition += Offset;
  }
  
}
