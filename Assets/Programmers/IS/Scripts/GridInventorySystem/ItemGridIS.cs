using System;
using UnityEngine;

/// <summary>
/// The script is responsible for getting the tile position on the inventory grid
/// </summary>

public class ItemGridIS : MonoBehaviour
{
    // tileSize needs to match the actual size of the slot asset in use
    [SerializeField] private float tileSize;
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridLength;
    [SerializeField] private GameObject inventoryItem;
    private RectTransform rectTrans;
    private Vector2 positionOnGrid = new Vector2();
    private Vector2Int tileGridPosition = new Vector2Int();
    private InventoryItemIS[,] inventoryItemSlots;

    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        InitGrid(gridWidth, gridLength);

        var item = Instantiate(inventoryItem).GetComponent<InventoryItemIS>();
        AddItem(item, 3, 1);
    }

    private void InitGrid(int width, int length)
    {
        inventoryItemSlots = new InventoryItemIS[width, length];
        Vector2 size = new Vector2(width * tileSize, length * tileSize);
        rectTrans.sizeDelta = size;
    }

    internal Vector2Int GetTileGridPosition(Vector2 mousePosition)
    {
        var rectTransPosition = rectTrans.position;
        positionOnGrid.x = mousePosition.x - rectTransPosition.x;
        positionOnGrid.y = rectTransPosition.y - mousePosition.y;

        tileGridPosition.x = (int)(positionOnGrid.x / tileSize);
        tileGridPosition.y = (int)(positionOnGrid.y / tileSize);

        return tileGridPosition;
    }

    internal void AddItem(InventoryItemIS itemToAdd, int posX, int posY)
    {
        var rt = itemToAdd.GetComponent<RectTransform>();
        rt.SetParent(rectTrans);
        inventoryItemSlots[posX, posY] = itemToAdd;

        Vector2 position = new Vector2
        {
            x = posX * tileSize + tileSize / 2,
            y = -(posY * tileSize + tileSize / 2)
        };

        rt.localPosition = position;
    }

    public InventoryItemIS PickUpItem(int x, int y)
    {
        var toReturn = inventoryItemSlots[x, y];
        inventoryItemSlots[x, y] = null;
        return toReturn;
    }
}
