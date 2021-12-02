using System;
using UnityEngine;

public class CameraZoomAA : MonoBehaviour
{
   [SerializeField] private float scrollSpeed = 20f;
   [SerializeField] private float minY = 20;
   [SerializeField] private float maxY = 120f;
   
   private void LateUpdate()
   {
      Vector3 cameraPosition = transform.position;
      //Check the scrolling This is what changes (Y value)
      float scroll = Input.GetAxis("Mouse ScrollWheel");
      cameraPosition.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
      cameraPosition.y = Mathf.Clamp(cameraPosition.y, minY, maxY);

      transform.position = cameraPosition;
   }
}
