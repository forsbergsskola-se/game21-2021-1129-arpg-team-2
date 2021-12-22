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
    
    [Header("Event")]
    [SerializeField] private GameEventInt addItemSuccessful;
    
    [Header("Information passed to grid")]
    [SerializeField] private ItemData pickedUpItem;
    [SerializeField] private GameObjectIdListValue pickedUpWorldItemIds;

    private InventoryItem selectedItem;
    private InventoryItem overlapItem;
    private RectTransform rectTrans;

    private bool isCursorInsideGrid;
    private ItemDropNextToPlayer itemDrop;

    private void Awake()
    {
        grid.rectTrans = GetComponent<RectTransform>();
        grid.InitGrid();
        pickedUpItem.ResetItemData();
        gameObject.SetActive(false);
        itemDrop = FindObjectOfType<ItemDropNextToPlayer>();
    }

    private void Update()
    {
        ItemIconStickToCursor();

        if (Input.GetMouseButtonDown(1) && !isCursorInsideGrid && selectedItem != null) DropItemNextToPlayer();
    }

    private void DropItemNextToPlayer()
    {
        var target = selectedItem.ItemData.WorldItemId;
        var find = pickedUpWorldItemIds.List.FirstOrDefault(x => x.id == target);

        find.worldItem.transform.position = itemDrop.transform.position;
        find.worldItem.SetActive(true);
        pickedUpWorldItemIds.RemoveFromList(find);
            
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
        var success = grid.AddItem(item.GetComponent<InventoryItem>(), targetGridCell.x, targetGridCell.y);
        if (success)
        {
            Debug.Log("Add new item successful");
            addItemSuccessful.Raise(pickedUpItem.WorldItemId);
            pickedUpItem.ResetItemData();
        }
    }
    
    private void AddItem(Vector2Int targetGridCell, InventoryItem existingItem)
    {
        var success = grid.AddItem(existingItem, targetGridCell.x, targetGridCell.y);
        if (success)
        {
            Debug.Log("Add back existing item succeeded");
            selectedItem = null;
        }
    }

    private void RemoveItem(Vector2Int targetGridCell)
    {
        selectedItem = grid.RemoveItem(targetGridCell.x, targetGridCell.y);
        if (selectedItem != null) rectTrans = selectedItem.GetComponent<RectTransform>();
    }

    public void OnQuickAdd()
    {
        var startSlot = grid.GetFirstAvailableSlot(pickedUpItem.width, pickedUpItem.height);
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
}
