using UnityEngine;
using UnityEngine.EventSystems;

public class WorldItemInteractIS : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private float distanceFromCamera;
    [SerializeField] private ItemDataIS pickedUpItem;

    private GridVisibleControllerIS gridVisibleControl;
    private bool isStickToCursor;
    private Camera cam;

    private void Awake()
    {
        gridVisibleControl = FindObjectOfType<GridVisibleControllerIS>();
        cam = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right) return;
        var clickCount = eventData.clickCount;
        switch (clickCount)
        {
            case 1:
                gridVisibleControl.SetGridVisibility(true);
                isStickToCursor = true;
                transform.LookAt(cam.transform);
                UpdatePickedUpItemData();

                break;
            case 2:
                Debug.Log("quick pick up fired");
                break;
        }
    }

    private void UpdatePickedUpItemData()
    {
        var currentItem = GetComponent<WorldItemIS>().ItemData;
        pickedUpItem.height = currentItem.height;
        pickedUpItem.width = currentItem.width;
        pickedUpItem.itemIcon = currentItem.itemIcon;
        pickedUpItem.HasValue = true;
    }

    private void Update()
    {
        if (isStickToCursor)
        {
            var mousePos = Input.mousePosition;
            mousePos.z = cam.nearClipPlane + distanceFromCamera;
            var mouseWorldPos = cam.ScreenToWorldPoint(mousePos);
            transform.position = mouseWorldPos;
        }
    }

    public void OnInventoryItemAddedSuccessful()
    {
        gameObject.SetActive(false);
    }
}
