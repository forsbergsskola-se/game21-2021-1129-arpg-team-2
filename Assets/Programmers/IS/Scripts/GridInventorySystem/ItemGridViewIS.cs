using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// The script controls
/// (1) initiating the grid
/// (2) listening for when an item dropped upon inventory space
/// </summary>

public class ItemGridViewIS : MonoBehaviour, IDropHandler
{
    [SerializeField] private ItemGridIS grid;
    [SerializeField] private GameObject itemPrefab;

    private void Awake()
    {
        grid.rectTrans = GetComponent<RectTransform>();
        grid.InitGrid();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("Item dropped inside inventory: " + eventData.pointerDrag.gameObject);
            var tileGridPosition = grid.GetTileGridPosition(Input.mousePosition);
            Debug.Log("on: " + tileGridPosition);
            // var itemToAdd = eventData.pointerDrag.GetComponent<InventoryItemIS>();
            var itemToAdd = Instantiate(itemPrefab).GetComponent<InventoryItemIS>();
            itemToAdd.Set(eventData.pointerDrag.GetComponent<InventoryItemIS>().itemData);
            var success = grid.AddItem(itemToAdd, tileGridPosition.x, tileGridPosition.y);
            Debug.Log("Adding item successful? " + success);
        }
    }
}
