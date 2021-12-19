using UnityEngine;
using UnityEngine.EventSystems;

public class WorldDraggerIS : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private GameObject target;
    private bool isDragging;
    private Vector3 offset;
    private Vector3 positionOfScreen;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("mouse down from WorldDraggerIS");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("dragging from WorldDraggerIS");
        Debug.Log("position: " + eventData.pointerCurrentRaycast.worldPosition);
        var currentPointerPosition = eventData.pointerCurrentRaycast.worldPosition;
        var newPos = new Vector3(currentPointerPosition.x, transform.position.y, currentPointerPosition.z);
        transform.position = newPos;
    }
}
