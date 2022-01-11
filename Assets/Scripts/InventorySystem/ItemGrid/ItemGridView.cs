using UnityEngine;
using UnityEngine.Events;
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
    [SerializeField] private GameObject carrotPool;
    [SerializeField] private GameObject potionPool;
    public ItemDatabase ItemDatabase;

    [HideInInspector] public UnityEvent ItemAddSuccess;

    private GameObject pickedUpGameObject;
    private BaseItem pickedUpItem;

    private InventoryItem selectedItem;
    private InventoryItem overlapItem;
    private RectTransform rectTrans;

    private bool isCursorInsideGrid;
    private ItemDropNextToPlayer itemDrop;

    private void Awake()
    {
        grid.rectTrans = GetComponent<RectTransform>();

        Debug.Log("before init: " + grid.GridSlots);

        if (grid.GridSlots == null) grid.InitGrid();
        else RepopulateGridView();
        
        Debug.Log("after init: " + grid.GridSlots);
        
        gameObject.SetActive(false);
        itemDrop = FindObjectOfType<ItemDropNextToPlayer>();
    }

    private void RepopulateGridView()
    {
        foreach (var item in ItemDatabase.itemDataList)
        {
            var temp = Instantiate(inventoryItem);
            temp.GetComponent<InventoryItem>().Set(item.Width, item.Height, item.ItemIcon, item.Type, item.SubType);
            var success = grid.AddItem(temp.GetComponent<InventoryItem>(), item.OnGridPositionX, item.OnGridPositionY, ref overlapItem);
            Debug.Log($"Repopulating grid view with item {item.Type}: {success}");
        }
    }

    private void OnEnable()
    {
        for (var x = 0; x < grid.Width; x++)
        {
            for (var y = 0; y < grid.Height; y++)
            {
                Debug.Log($"what's inside grid[{ x }, { y }]: {grid.GridSlots[x, y]}");
            }
        }
    }

    private void Update()
    {
        ItemIconStickToCursor();

        if (Input.GetMouseButtonDown(1) && !isCursorInsideGrid && selectedItem != null) DropItemNextToPlayer();
    }

    private void DropItemNextToPlayer()
    {
        var targetType = selectedItem.itemData.Type;
        var targetSubType = selectedItem.itemData.SubType;

        GameObject find;
        if (targetType is ItemType.Consumable && targetSubType == (int) ConsumableType.Carrot)
            find = carrotPool.GetComponent<CarrotPool>().Pop();
        else if (targetType is ItemType.Consumable && targetSubType == (int) ConsumableType.Potion)
            find = potionPool.GetComponent<PotionPool>().Pop();
        else find = null;
        
        find.transform.position = itemDrop.transform.position;
        find.SetActive(true);
        // find.GetComponent<WorldItem>().StartExpirationCountDown();
        
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
        if (pickedUpItem != null) AddItem(targetGridCell);
        else if (selectedItem != null) AddItem(targetGridCell, selectedItem);
        else RemoveItem(targetGridCell);
    }
    
    private void ConsumeInventoryItem(Vector2Int targetGridCell)
    {
        RemoveItem(targetGridCell);
        
        var targetType = selectedItem.itemData.Type;
        var targetSubType = selectedItem.itemData.SubType;
        
        if (targetType is ItemType.Consumable && targetSubType == (int)ConsumableType.Carrot)
        {
            var find = carrotPool.GetComponent<CarrotPool>().Pop();
            find.GetComponent<ConsumeWorldItem>().PlayerConsumeConsumable();
            Destroy(selectedItem.gameObject);
            selectedItem = null;
        }
        else if (targetType is ItemType.Consumable && targetSubType == (int)ConsumableType.Potion)
        {
            var find = potionPool.GetComponent<PotionPool>().Pop();
            find.GetComponent<ConsumeWorldItem>().PlayerConsumeConsumable();
            Destroy(selectedItem.gameObject);
            selectedItem = null;
        }
    }

    private void AddItem(Vector2Int targetGridCell)
    {
        var item = Instantiate(inventoryItem);
        ItemType type;
        int? subType;
        
         switch (pickedUpItem)
         {
             case ConsumableItem c when c:
                 type = c.Type;
                 subType = (int) c.SubType;
                 break;
             case WeaponItem w when w:
                 type = w.Type;
                 subType = (int) w.SubType;
                 break;
             case QuestItem q when q:
                 type = q.Type;
                 subType = (int) q.SubType;
                 break;
             default:
                 type = ItemType.None;
                 subType = null;
                 break;
         }
        
        item.GetComponent<InventoryItem>().Set(pickedUpItem.InventoryItemWidth, pickedUpItem.InventoryItemHeight, pickedUpItem.InventoryItemIcon, type, subType);

        var success = grid.AddItem(item.GetComponent<InventoryItem>(), targetGridCell.x, targetGridCell.y, ref overlapItem);
        if (success)
        {
            selectedItem = null;
            if (overlapItem != null) HandleItemOverlap();

            pickedUpGameObject.GetComponent<PickupWorldItem>().OnItemAddSuccess();
            ItemAddSuccess?.Invoke();
            pickedUpItem = null;
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

    public void QuickAdd()
    {
        // TODO: GetFirstAvailableSlot() is buggy and needs fixing; putting it in a try-catch for now to avoid exception
        var startSlot = grid.GetFirstAvailableSlot(pickedUpItem.InventoryItemWidth, pickedUpItem.InventoryItemHeight);
        AddItem(startSlot);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        isCursorInsideGrid = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isCursorInsideGrid = false;
    }

    public void OnPrepareQuickAdd(PickUp tmp)
    {
        pickedUpItem = tmp.item;
        pickedUpGameObject = tmp.itemGameObject;
        QuickAdd();
    }

    public void OnPrepareRegularAdd(PickUp tmp)
    {
        pickedUpItem = tmp.item;
        pickedUpGameObject = tmp.itemGameObject;
    }
}
