using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class SetSelectedItemGridIS : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ItemGridIS itemGrid;
    [SerializeField] private List<ItemDataIS> itemList;
    [SerializeField] private GameObject itemPrefab;
    private InventoryControllerIS inventoryController;
    private int itemSpawned = 0;

    private void Awake()
    {
        inventoryController = FindObjectOfType<InventoryControllerIS>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        inventoryController.selectedItemGrid = 
            inventoryController.selectedItemGrid == null ? itemGrid : null;
        ToggleItemGrid();
    }

    private void Update()
    {
        if (itemGrid.inventoryItemSlots != null && itemSpawned == 0)
        {
            CreateRandomItem();
            itemSpawned++;
        }
    }

    private void CreateRandomItem()
    {
        var item = Instantiate(itemPrefab).GetComponent<InventoryItemIS>();
        inventoryController.selectedItem = item;
        inventoryController.recTrans = item.GetComponent<RectTransform>();
        inventoryController.recTrans.SetParent(inventoryController.canvasTransform);
        item.Set(itemList[Random.Range(0, itemList.Count)]);
        
        inventoryController.PlaceItem(new Vector2Int(0, 1));
    }

    private void ToggleItemGrid() => itemGrid.transform.gameObject.SetActive(!itemGrid.transform.gameObject.activeInHierarchy);
}
