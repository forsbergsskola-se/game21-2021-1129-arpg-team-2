using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleTestIS : MonoBehaviour
{
    // [SerializeField] private GameEventIS clickOnDesctructible;
    private PlayernavMeshIS navmesh;

    private void Awake()
    {
        navmesh = FindObjectOfType<PlayernavMeshIS>();
    }

    private void OnMouseUp()
    {
        // clickOnDesctructible.Raise();
        var temp = ScriptableObject.CreateInstance<Vector3Value>();
        temp.Vector3 = transform.position;
        navmesh.entityDestination = temp;
        navmesh.TestTest();
    }
}
