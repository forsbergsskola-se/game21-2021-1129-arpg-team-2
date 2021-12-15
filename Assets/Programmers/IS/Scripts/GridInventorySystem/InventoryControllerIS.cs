using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The script is responsible for detecting which grid cell is selected
/// </summary>
public class InventoryControllerIS : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] internal ItemGridIS selectedItemGrid;

    [SerializeField] private List<ItemDataIS> itemList;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform canvasTransform;

    private InventoryItemIS selectedItem;
    private RectTransform recTrans;

    private void Update()
    {
        ItemIconDrag();

        if (Input.GetKeyDown(KeyCode.Q)) CreateRandomItem();
        
        if (selectedItemGrid == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            LeftMouseBtnPress();
        }
    }

    private void CreateRandomItem()
    {
        var item = Instantiate(itemPrefab).GetComponent<InventoryItemIS>();
        selectedItem = item;
        recTrans = item.GetComponent<RectTransform>();
        recTrans.SetParent(canvasTransform);
        item.Set(itemList[Random.Range(0, itemList.Count)]);
    }

    private void ItemIconDrag()
    {
        if (selectedItem != null) recTrans.position = Input.mousePosition;
    }
    
    private void LeftMouseBtnPress()
    {
        var tileGridPosition = selectedItemGrid.GetTileGridPosition(Input.mousePosition);
        if (selectedItem == null) PickupItem(tileGridPosition);
        else PlaceItem(tileGridPosition);
    }
    
    private void PickupItem(Vector2Int tileGridPosition)
    {
        selectedItem = selectedItemGrid.PickUpItem(tileGridPosition.x, tileGridPosition.y);
        if (selectedItem != null) recTrans = selectedItem.GetComponent<RectTransform>();
    }

    private void PlaceItem(Vector2Int tileGridPosition)
    {
        selectedItemGrid.AddItem(selectedItem, tileGridPosition.x, tileGridPosition.y);
        selectedItem = null;
    }
}
