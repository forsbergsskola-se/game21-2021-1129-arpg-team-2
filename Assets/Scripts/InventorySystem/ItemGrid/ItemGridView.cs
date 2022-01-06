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

    internal GameObject currentWorldItemGameObject;
    private BaseItem currentWorldItem;

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
        gameObject.SetActive(false);
        itemDrop = FindObjectOfType<ItemDropNextToPlayer>();
        
        spawnWorldItems = FindObjectsOfType<WorldItem>();
        spawnWorldItems.ToList().ForEach(x => x.gameObject.GetComponent<PickupWorldItem>().WorldItemChosen += OnWorldItemChosen);
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

        WorldItem find;
        if (targetType is ItemType.Consumable)
            find = spawnWorldItems.FirstOrDefault(x =>
                x.Item.ItemType == targetType && (int)x.Item.ConsumableType == targetSubType);
        else find = null;
        
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
        var targetGridCell = grid.GetTileGridPosition(Input.mousePosition);
        if (eventData.button == PointerEventData.InputButton.Right && isCursorInsideGrid) PickupInventoryItem();
        else if (eventData.button == PointerEventData.InputButton.Left &&
                 Input.GetKey(KeyCode.LeftControl) &&
                 grid.IsGridTileOccupied(targetGridCell) &&
                 isCursorInsideGrid
        ) ConsumeInventoryItem(targetGridCell);
    }

    private void PickupInventoryItem()
    {
        var targetGridCell = grid.GetTileGridPosition(Input.mousePosition);
        if (currentWorldItem != null) AddItem(targetGridCell);
        else if (selectedItem != null) AddItem(targetGridCell, selectedItem);
        else RemoveItem(targetGridCell);
    }
    
    private void ConsumeInventoryItem(Vector2Int targetGridCell)
    {
        RemoveItem(targetGridCell);
        
        var targetType = selectedItem.ItemData.Type;
        var targetSubType = selectedItem.ItemData.SubType;

        WorldItem find = null;
        if (targetType is ItemType.Consumable)
        {
            find = spawnWorldItems.FirstOrDefault(x =>
                x.Item.ItemType == targetType && (int)x.Item.ConsumableType == targetSubType);
            find.gameObject.GetComponent<ConsumeWorldItem>().PlayerConsumeConsumable();
            
            Destroy(selectedItem.gameObject);
            selectedItem = null;
        }
        
    }

    private void AddItem(Vector2Int targetGridCell)
    {
        var item = Instantiate(inventoryItem);
        item.GetComponent<InventoryItem>().Set(currentWorldItem);

        var success = grid.AddItem(item.GetComponent<InventoryItem>(), targetGridCell.x, targetGridCell.y, ref overlapItem);
        if (success)
        {
            selectedItem = null;
            if (overlapItem != null) HandleItemOverlap();

            currentWorldItemGameObject.GetComponent<PickupWorldItem>().OnItemAddSuccess();
            currentWorldItem = null;
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
            var startSlot = grid.GetFirstAvailableSlot(currentWorldItem.InventoryItemWidth, currentWorldItem.InventoryItemHeight);
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

    private void OnWorldItemChosen(BaseItem item) => currentWorldItem = item;
}
