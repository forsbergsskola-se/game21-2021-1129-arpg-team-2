using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// The script controls
/// (1) initiating the grid
/// (2) listening drop release
/// </summary>

public class ItemGridViewIS : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ItemGridIS grid;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private ItemDataIS pickedUpItem;
    [SerializeField] private GameEvent addItemSuccessful;

    private InventoryItemIS selectedItem;

    private void Awake()
    {
        grid.rectTrans = GetComponent<RectTransform>();
        grid.InitGrid();
        pickedUpItem.ResetItemData();
    }

    // public void OnDrop(PointerEventData eventData)
    // {
    //     if (eventData.pointerDrag != null)
    //     {
    //         Debug.Log("Item dropped inside inventory: " + eventData.pointerDrag.gameObject);
    //         var tileGridPosition = grid.GetTileGridPosition(Input.mousePosition);
    //         Debug.Log("on: " + tileGridPosition);
    //         var itemToAdd = Instantiate(itemPrefab).GetComponent<InventoryItemIS>();
    //         itemToAdd.Set(eventData.pointerDrag.GetComponent<InventoryItemIS>().itemData);
    //         var success = grid.AddItem(itemToAdd, tileGridPosition.x, tileGridPosition.y);
    //         Debug.Log("Adding item successful? " + success);
    //         if (success) eventData.pointerDrag.gameObject.SetActive(false);
    //     }
    // }

    public void OnPointerDown(PointerEventData eventData)
    {
        // check if clicked grid cell is occupied
        // if yes, pick up item
        // if right click + selectedItem != null
        if (eventData.button != PointerEventData.InputButton.Right) return;
        var targetGridCell = grid.GetTileGridPosition(Input.mousePosition);
        Debug.Log("grid cell clicked: " + targetGridCell);
        Debug.Log("pickedUpItem has value: " + pickedUpItem.HasValue);
        if (pickedUpItem.HasValue) AddItem(targetGridCell);
        // if (IsOverlap())
        // {
        //     // swapping logic goes here, not now though
        // }
        Debug.Log("picked up item: " + pickedUpItem.width + " " + pickedUpItem.height);
    }

    private void AddItem(Vector2Int targetGridCell)
    {
        var inventoryItem = Instantiate(itemPrefab);
        inventoryItem.GetComponent<InventoryItemIS>().Set(pickedUpItem);
        var success = grid.AddItem(inventoryItem.GetComponent<InventoryItemIS>(), targetGridCell.x, targetGridCell.y);
        if (success)
        {
            pickedUpItem.ResetItemData();
            addItemSuccessful.Raise();
        }
    }

    private bool IsOverlap() => false;
}
