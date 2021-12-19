using UnityEngine;
using UnityEngine.EventSystems;

public class WorldDraggerIS : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private float distanceFromGround;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

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

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position += new Vector3(0, distanceFromGround, 0);
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
