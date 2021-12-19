using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetSelectedItemGridIS : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ItemGridIS itemGrid;
    
    // for development only, NOT final
    [SerializeField] private List<ItemDataIS> itemList;
    [SerializeField] private GameObject itemPrefab;
    // for development only, NOT final
    
    private InventoryControllerIS inventoryController;

    private void Awake()
    {
        inventoryController = FindObjectOfType<InventoryControllerIS>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        inventoryController.selectedItemGrid = 
            inventoryController.selectedItemGrid == null ? itemGrid : null;
        ToggleItemGrid();
        
        // DEVELOPMENT ONLY
        CreateRandomItem();
        // DEVELOPMENT ONLY
    }

    private void CreateRandomItem()
    {
        var item = Instantiate(itemPrefab).GetComponent<InventoryItemIS>();
        inventoryController.selectedItem = item;
        inventoryController.recTrans = item.GetComponent<RectTransform>();
        inventoryController.recTrans.SetParent(inventoryController.canvasTransform);
        item.Set(itemList[0]);
        
        inventoryController.PlaceItem(new Vector2Int(0, 1));
    }

    private void ToggleItemGrid() => itemGrid.transform.gameObject.SetActive(!itemGrid.transform.gameObject.activeInHierarchy);
}
