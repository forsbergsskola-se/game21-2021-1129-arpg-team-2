using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// The script controls
/// (1) initiating the grid
/// (2) controlling when to call what grid operation logic
/// The script should be used in pair with ItemGrid scriptable object
/// </summary>

public class ItemGridViewIS : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] private ItemGridIS grid;
    [SerializeField] private GameObject inventoryItem;
    [SerializeField] private ItemDataIS pickedUpItem;
    [SerializeField] private GameEvent addItemSuccessful;

    private InventoryItemIS selectedItem;
    private InventoryItemIS overlapItem;
    private RectTransform rectTrans;

    private bool isCursorOutsideGrid;

    private void Awake()
    {
        grid.rectTrans = GetComponent<RectTransform>();
        grid.InitGrid();
        pickedUpItem.ResetItemData();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        ItemIconStickToCursor();

        if (Input.GetMouseButtonDown(1) && isCursorOutsideGrid)
        {
            Debug.Log("right click outside grid view detected");
        }
    }

    private void ItemIconStickToCursor()
    {
        if (selectedItem != null)
        {
            rectTrans.position = Input.mousePosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right) return;
        var targetGridCell = grid.GetTileGridPosition(Input.mousePosition);
        
        // Debug.Log("grid cell clicked: " + targetGridCell);
        
        if (pickedUpItem.HasValue) AddItem(targetGridCell);
        else if (selectedItem != null) AddItem(targetGridCell, selectedItem);
        else RemoveItem(targetGridCell);
    }

    private void AddItem(Vector2Int targetGridCell)
    {
        Debug.Log("Add new item is hit");
        var item = Instantiate(inventoryItem);
        item.GetComponent<InventoryItemIS>().Set(pickedUpItem);
        var success = grid.AddItem(item.GetComponent<InventoryItemIS>(), targetGridCell.x, targetGridCell.y);
        if (success)
        {
            pickedUpItem.ResetItemData();
            addItemSuccessful.Raise();
        }
    }
    
    private void AddItem(Vector2Int targetGridCell, InventoryItemIS existingItem)
    {
        Debug.Log("Add back existing item is hit");
        var success = grid.AddItem(existingItem, targetGridCell.x, targetGridCell.y);
        if (success)
        {
            Debug.Log("add back existing item succeeded");
            selectedItem = null;
        }
    }

    private void RemoveItem(Vector2Int targetGridCell)
    {
        Debug.Log("Remove item is hit");
        selectedItem = grid.RemoveItem(targetGridCell.x, targetGridCell.y);
        if (selectedItem != null) rectTrans = selectedItem.GetComponent<RectTransform>();
    }

    public void OnQuickAdd()
    {
        var startSlot = grid.GetFirstAvailableSlot(pickedUpItem.width, pickedUpItem.height);
        // Debug.Log("Available start position: " + startSlot);
        AddItem(startSlot);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isCursorOutsideGrid = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isCursorOutsideGrid = false;
    }
}
