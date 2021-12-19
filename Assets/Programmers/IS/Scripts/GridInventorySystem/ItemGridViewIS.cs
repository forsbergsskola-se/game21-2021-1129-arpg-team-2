using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// The script controls
/// (1) the size of the grid
/// (2) initiating the grid
/// (3) adding/picking up item from the grid
/// </summary>

public class ItemGridViewIS : MonoBehaviour, IDropHandler
{
    [SerializeField] private ItemGridIS grid;

    private void Awake()
    {
        grid.rectTrans = GetComponent<RectTransform>();
        grid.InitGrid();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item dropped inside inventory!");
        if (eventData.pointerDrag != null)
        {
            var tileGridPosition = grid.GetTileGridPosition(Input.mousePosition);
            
            var itemToAdd = eventData.pointerDrag.GetComponent<InventoryItemIS>();
            var success = grid.AddItem(itemToAdd, tileGridPosition.x, tileGridPosition.y);
            Debug.Log("Adding item successful? " + success);
        }
    }
}
