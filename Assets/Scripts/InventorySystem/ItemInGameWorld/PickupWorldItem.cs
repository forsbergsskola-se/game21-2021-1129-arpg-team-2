using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Controls how WorldItem interacts with event and/or user input
/// </summary>

public class PickupWorldItem : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private float distanceFromCamera;
    [SerializeField] private BaseItem pickedUpItem;
    [SerializeField] private ItemGridView grid;

    // Inventory-UI-related
    private GridVisibleController gridVisibleControl;
    private bool isStickToCursor;
    private Camera cam;

    private void Awake()
    {
        gridVisibleControl = FindObjectOfType<GridVisibleController>();
        cam = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && Input.GetKey(KeyCode.LeftControl))
        {
            UpdatePickedUpItemData();
            grid.currentWorldItem = gameObject;
            grid.OnQuickAdd();
        }
        else
        {
            gridVisibleControl.SetGridVisibility(true);
            grid.currentWorldItem = gameObject;
            isStickToCursor = true;
            transform.LookAt(cam.transform);
            UpdatePickedUpItemData();
        }
    }

    private void UpdatePickedUpItemData()
    {
        var currentItem = GetComponent<WorldItem>().Item;
        pickedUpItem.SetItemData(currentItem.InventoryItemIcon, currentItem.InventoryItemWidth, currentItem.InventoryItemHeight, currentItem.ItemType, currentItem.Description, true, (int)currentItem.SubType);
    }

    private void Update()
    {
        if (isStickToCursor) ItemStickToCursor();
    }

    private void ItemStickToCursor()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = cam.nearClipPlane + distanceFromCamera;
        var mouseWorldPos = cam.ScreenToWorldPoint(mousePos);
        transform.position = mouseWorldPos;
    }

    public void OnItemAddSuccess()
    {
        isStickToCursor = false;
        gameObject.SetActive(false);
    }
}
