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
    [SerializeField] private GameObject inventoryItem;
    [SerializeField] private ItemDataIS pickedUpItem;
    [SerializeField] private GameEvent addItemSuccessful;

    private InventoryItemIS selectedItem;

    private void Awake()
    {
        grid.rectTrans = GetComponent<RectTransform>();
        grid.InitGrid();
        pickedUpItem.ResetItemData();
        gameObject.SetActive(false);
    }

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
        var item = Instantiate(inventoryItem);
        item.GetComponent<InventoryItemIS>().Set(pickedUpItem);
        var success = grid.AddItem(item.GetComponent<InventoryItemIS>(), targetGridCell.x, targetGridCell.y);
        if (success)
        {
            pickedUpItem.ResetItemData();
            addItemSuccessful.Raise();
        }
    }

    private bool IsOverlap() => false;

    public void OnQuickAdd()
    {
        var item = Instantiate(inventoryItem);
        item.GetComponent<InventoryItemIS>().Set(pickedUpItem);
        
        // a method to get consecutive available slots
        
        AddItem(new Vector2Int(2, 0));
    }
}
