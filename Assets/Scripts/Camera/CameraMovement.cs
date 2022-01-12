using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class CameraMovement : MonoBehaviour
{
    [Header("Position")]
    [SerializeField] private Vector3Value playerPosition;
    [SerializeField] private Vector3 cameraOffset;

    [Header("Rotation")]
    [SerializeField] [Range(0.1f, 1f)] private float smoothFactor = 0.5f;
    [SerializeField] private bool lookAtPlayer;
    [SerializeField] private bool rotateAroundPlayer;
    [SerializeField] private float rotationSpeed = 3f;
    [SerializeField] private float distanceToBorder = 15f;
    
    [Header("Scroll")]
    [SerializeField] private float scrollSpeed = 20f;
    [SerializeField] private float minY = 20;
    [SerializeField] private float maxY = 120f;
    
    
    
    private void Start()
    {
        cameraOffset = transform.position - playerPosition.Vector3;
    }

    private void LateUpdate()
    {
        float rotationMagnite = 0;
        if (!EventSystem.current.IsPointerOverGameObject()) {
            
            if (Input.mousePosition.x <= distanceToBorder)
            {
                rotationMagnite = -1;
            }
            else if (Input.mousePosition.x >= Screen.width - distanceToBorder)
            {
                rotationMagnite = 1;
            }
            else
            {
                rotationMagnite = 0;
            }
            
            if (rotateAroundPlayer)
            {
                Quaternion camTurnAngle = Quaternion.AngleAxis(rotationMagnite * rotationSpeed / 100, Vector3.up);

                cameraOffset = camTurnAngle * cameraOffset;
            }
        }
       
        //Check the scrolling This is what changes (Y value)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cameraOffset.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
        cameraOffset.y = Mathf.Clamp(cameraOffset.y, minY, maxY);

        Vector3 newPos = playerPosition.Vector3 + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (lookAtPlayer || rotateAroundPlayer)
        {
            transform.LookAt(playerPosition.Vector3);
        }
    }

    private void DebugMouseRaycast() {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);
        for (int i = 0; i < raycastResults.Count; i++) {
            Debug.Log(raycastResults[i].gameObject);
        }
    }
}