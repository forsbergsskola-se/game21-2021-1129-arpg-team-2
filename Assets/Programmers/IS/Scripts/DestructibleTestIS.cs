using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleTestIS : MonoBehaviour
{
    // [SerializeField] private GameEventIS clickOnDesctructible;
//
//     [SerializeField] private FloatValue playerRange;
//     
//     private PlayernavMeshIS navmesh;
//     
//     
//
//     private void Awake()
//     {
//         navmesh = FindObjectOfType<PlayernavMeshIS>();
//     }
//
//     private void Update()
//     {
//         if (Vector3.Distance(navmesh.gameObject.transform.position, transform.position) <= playerRange.RuntimeValue)
//         {
//             var destination = ScriptableObject.CreateInstance<Vector3Value>();
//             destination.Vector3 = navmesh.transform.position;
//             navmesh.entityDestination = destination; 
//             
//             Debug.Log("InRange");
//         }
//     }
//
//     private void OnMouseUp()
//     {
//         // clickOnDesctructible.Raise();
//         var temp = ScriptableObject.CreateInstance<Vector3Value>();
//         temp.Vector3 = transform.position;
//         navmesh.entityDestination = temp;
//         navmesh.TestTest();
//     }
}
