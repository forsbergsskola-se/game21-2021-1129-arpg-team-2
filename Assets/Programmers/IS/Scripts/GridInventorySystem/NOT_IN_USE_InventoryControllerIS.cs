using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

/// <summary>
/// The script is responsible for detecting which grid cell is selected
/// </summary>
public class InventoryControllerIS : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] internal ItemGridIS selectedItemGrid;

    // [SerializeField] private List<ItemDataIS> itemList;
    // [SerializeField] private GameObject itemPrefab;
    [SerializeField] internal Transform canvasTransform;

    internal InventoryItemIS selectedItem;
    private InventoryItemIS overlapItem;
    internal RectTransform recTrans;

    private void Update()
    {
        // ItemIconDrag();

        // if (Input.GetKeyDown(KeyCode.Q)) CreateRandomItem();

        // if (selectedItemGrid == null) return;

        // if (Input.GetMouseButtonDown(0))
        // {
        //     LeftMouseBtnPress();
        // }
    }

    private void ItemIconDrag()
    {
        if (selectedItem != null) recTrans.position = Input.mousePosition;
    }
    
    // private void LeftMouseBtnPress()
    // {
    //     var tileGridPosition = selectedItemGrid.GetTileGridPosition(Input.mousePosition);
    //     if (selectedItem == null) PickupItem(tileGridPosition);
    //     else PlaceItem(tileGridPosition);
    // }
    
    // private void PickupItem(Vector2Int tileGridPosition)
    // {
    //     selectedItem = selectedItemGrid.PickUpItem(tileGridPosition.x, tileGridPosition.y);
    //     if (selectedItem != null) recTrans = selectedItem.GetComponent<RectTransform>();
    // }

    internal void PlaceItem(Vector2Int tileGridPosition)
    {
        // var successful = selectedItemGrid.AddItem(selectedItem, tileGridPosition.x, tileGridPosition.y, ref overlapItem);
        // if (successful)
        // {
        //     selectedItem = null;
        //     if (overlapItem != null)
        //     {
        //         selectedItem = overlapItem;
        //         overlapItem = null;
        //         recTrans = selectedItem.GetComponent<RectTransform>();
        //     }
        // }
    }
}
