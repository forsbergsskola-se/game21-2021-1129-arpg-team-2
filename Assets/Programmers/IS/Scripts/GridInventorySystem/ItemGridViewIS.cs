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

    private InventoryItemIS selectedItem;

    private void Awake()
    {
        grid.rectTrans = GetComponent<RectTransform>();
        grid.InitGrid();
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
        // if right click + selectedItem != null
        Debug.Log("grid cell clicked: " + grid.GetTileGridPosition(Input.mousePosition));
    }
}
