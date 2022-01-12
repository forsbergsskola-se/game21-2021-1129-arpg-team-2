using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PlayernavMeshJO : MonoBehaviour
{
    [SerializeField] private Vector3Value playerPosition;
    
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    
    private void Awake()
    {
         navMeshAgent = GetComponent<NavMeshAgent>();
         playerPosition.Vector3 = transform.position;
    }

    private void Update()
    {
        //navMeshAgent.destination = movePositionTransform.position;
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            //var hit: RaycastHit;
                
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100) & SetDestination(hit.transform.position)) {
                navMeshAgent.destination = hit.point;
            }
        }

        playerPosition.Vector3 = transform.position;
    }
    
    private bool SetDestination(Vector3 targetDestination)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetDestination, out hit, 1f, NavMesh.AllAreas))
        {
            navMeshAgent.SetDestination(hit.position);
            return true;
        }
        return false;
    }
}

