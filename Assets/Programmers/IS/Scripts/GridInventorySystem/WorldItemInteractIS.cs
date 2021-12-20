using UnityEngine;
using UnityEngine.EventSystems;

public class WorldItemInteractIS : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private float distanceFromCamera;
    private ItemGridViewIS gridView;
    private bool isStickToCursor;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("pointer down fired");
        if (eventData.button != PointerEventData.InputButton.Right) return;
        var clickCount = eventData.clickCount;
        switch (clickCount)
        {
            case 1:
                Debug.Log("pick-up requires inventory active fired");
                // bring up inventory view
                // world item sticks to cursor
                isStickToCursor = true;
                transform.LookAt(cam.transform);
                // drop in the inventory area with another one right click
                
                break;
            case 2:
                Debug.Log("quick pick up fired");
                break;
        }
    }

    private void Update()
    {
        if (isStickToCursor)
        {
            var mousePos = Input.mousePosition;
            mousePos.z = cam.nearClipPlane + distanceFromCamera;
            var mouseWorldPos = cam.ScreenToWorldPoint(mousePos);
            Debug.Log("Mouse position: " + mouseWorldPos);
            transform.position = mouseWorldPos;
        }
    }
}
