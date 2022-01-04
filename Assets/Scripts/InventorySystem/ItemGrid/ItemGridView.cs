using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// The script controls
/// (1) initiating the grid
/// (2) controlling when to call what grid operation logic
/// The script should be used in pair with ItemGrid scriptable object
/// </summary>

public class ItemGridView : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerEnterHandler
{
    [Header("Grid")]
    [SerializeField] private ItemGrid grid;
    [SerializeField] private GameObject inventoryItem;

    [Header("Data passed to grid")]
    [SerializeField] private BaseItem pickedUpItem;
    [SerializeField] internal GameObject currentWorldItem;

    private InventoryItem selectedItem;
    private InventoryItem overlapItem;
    private RectTransform rectTrans;

    private bool isCursorInsideGrid;
    private ItemDropNextToPlayer itemDrop;

    private WorldItem[] spawnWorldItems;

    private void Awake()
    {
        grid.rectTrans = GetComponent<RectTransform>();
        grid.InitGrid();
        pickedUpItem.ResetItemData();
        gameObject.SetActive(false);
        itemDrop = FindObjectOfType<ItemDropNextToPlayer>();
        
        spawnWorldItems = FindObjectsOfType<WorldItem>();
    }

    private void Update()
    {
        ItemIconStickToCursor();

        if (Input.GetMouseButtonDown(1) && !isCursorInsideGrid && selectedItem != null) DropItemNextToPlayer();
    }

    private void DropItemNextToPlayer()
    {
        var targetType = selectedItem.ItemData.Type;
        var targetSubType = selectedItem.ItemData.SubType;
        var find = spawnWorldItems.FirstOrDefault(x => x.Item.ItemType == targetType && (int)x.Item.SubType == targetSubType);

        find.gameObject.transform.position = itemDrop.transform.position;
        find.gameObject.SetActive(true);
        Destroy(selectedItem.gameObject);
        selectedItem = null;
    }

    private void ItemIconStickToCursor()
    {
        if (selectedItem != null) rectTrans.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right || !isCursorInsideGrid) return;
        var targetGridCell = grid.GetTileGridPosition(Input.mousePosition);

        if (pickedUpItem.HasValue) AddItem(targetGridCell);
        else if (selectedItem != null) AddItem(targetGridCell, selectedItem);
        else RemoveItem(targetGridCell);
    }

    private void AddItem(Vector2Int targetGridCell)
    {
        var item = Instantiate(inventoryItem);
        item.GetComponent<InventoryItem>().Set(pickedUpItem);

        var success = grid.AddItem(item.GetComponent<InventoryItem>(), targetGridCell.x, targetGridCell.y, ref overlapItem);
        if (success)
        {
            selectedItem = null;
            if (overlapItem != null) HandleItemOverlap();
            
            currentWorldItem.GetComponent<PickupWorldItem>().OnItemAddSuccess();
            pickedUpItem.ResetItemData();
        }
    }

    private void AddItem(Vector2Int targetGridCell, InventoryItem existingItem)
    {
        var success = grid.AddItem(existingItem, targetGridCell.x, targetGridCell.y, ref overlapItem);
        if (success)
        {
            selectedItem = null;
            if (overlapItem != null) HandleItemOverlap();
        }
    }
    
    private void HandleItemOverlap()
    {
        selectedItem = overlapItem;
        overlapItem = null;
        rectTrans = selectedItem.GetComponent<RectTransform>();
    }

    private void RemoveItem(Vector2Int targetGridCell)
    {
        selectedItem = grid.RemoveItem(targetGridCell.x, targetGridCell.y);
        if (selectedItem != null) rectTrans = selectedItem.GetComponent<RectTransform>();
    }

    public void OnQuickAdd()
    {
        // TODO: GetFirstAvailableSlot() is buggy and needs fixing; putting it in a try-catch for now to avoid exception
        try
        {
            var startSlot = grid.GetFirstAvailableSlot(pickedUpItem.InventoryItemWidth, pickedUpItem.InventoryItemHeight);
            AddItem(startSlot);
        }
        catch (Exception e)
        {
            Console.WriteLine("Grid operation error: Available space not found");
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        isCursorInsideGrid = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isCursorInsideGrid = false;
    }
}
