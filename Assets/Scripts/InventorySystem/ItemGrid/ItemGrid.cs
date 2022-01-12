using System;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// This scriptable object
/// (1) stores configuration on the item grid
/// (2) controls adding and removing logic and validation of doing so
/// </summary>

[CreateAssetMenu(fileName = "Inventory grid", menuName = "Game/Inventory/Inventory grid")]
public class ItemGrid : ScriptableObject
{
    [Header("Grid configuration")]
    [Header("Tile size NEEDS to match the exact size of the square tile used in pixel")]
    [SerializeField] private float tileSize;
    [SerializeField] private int width;
    [SerializeField] private int height;
    // public ItemDatabase itemDatabase;
    // public GameObject inventoryItem;
    
    internal RectTransform rectTrans;
    public float TileSize => tileSize;
    public int Width => width;
    public int Height => height;
    
    public InventoryItem[,] gridSlots;
    private Vector2 positionOnGrid;
    private Vector2Int tileGridPosition;

    public void InitGrid()
    {
        gridSlots = new InventoryItem[width, height];
        var size = new Vector2(width * tileSize, height * tileSize);
        rectTrans.sizeDelta = size;
    }
    
    // public void RepopulateGridView()
    // {
    //     foreach (var item in itemDatabase.itemDataList)
    //     {
    //         Debug.Log($"Repopulating grid view with item {item.Type}: {item.SubType}");
    //         
    //         var temp = Instantiate(inventoryItem);
    //         temp.GetComponent<InventoryItem>().Set(item.Width, item.Height, item.ItemIcon, item.Type, item.SubType);
    //         var rt = temp.GetComponent<RectTransform>();
    //         rt.SetParent(rectTrans);
    //
    //         for (var i = 0; i < item.Width; i++)
    //         {
    //             for (var j = 0; j < item.Height; j++)
    //             {
    //                 Debug.Log("item" + item.Type);
    //                 Debug.Log("GridSlots: " + gridSlots);
    //                 Debug.Log("item posX: " + item.OnGridPositionX);
    //                 Debug.Log("item posY: " + item.OnGridPositionY);
    //                 gridSlots[item.OnGridPositionX + i, item.OnGridPositionY + j] = temp.GetComponent<InventoryItem>();
    //             }
    //         }
    //
    //         var position = new Vector2
    //         {
    //             x = item.OnGridPositionX * tileSize + tileSize * item.Width / 2,
    //             y = -(item.OnGridPositionY * tileSize + tileSize * item.Height / 2)
    //         };
    //         rt.localPosition = position;
    //     }
    // }
    

    public bool AddItem(InventoryItem itemToAdd, int posX, int posY, ref InventoryItem overlapItem)
    {
        
        if (IsItemOutsideInventory(posX, posY, itemToAdd.itemData.Width, itemToAdd.itemData.Height)) return false;
        
        if (IsItemOverlap(posX, posY, itemToAdd.itemData.Width, itemToAdd.itemData.Height, ref overlapItem))
        {
            overlapItem = null;
            return false;
        }
        if (overlapItem != null) CleanGridReference(overlapItem);
        
        var rt = itemToAdd.GetComponent<RectTransform>();
        rt.SetParent(rectTrans);

        for (var i = 0; i < itemToAdd.itemData.Width; i++)
        {
            for (var j = 0; j < itemToAdd.itemData.Height; j++)
            {
                gridSlots[posX + i, posY + j] = itemToAdd;
            }
        }

        var position = new Vector2
        {
            x = posX * tileSize + tileSize * itemToAdd.itemData.Width / 2,
            y = -(posY * tileSize + tileSize * itemToAdd.itemData.Height / 2)
        };
        rt.localPosition = position;
        
        // itemToAdd.itemData.OnGridPositionX = posX;
        // itemToAdd.itemData.OnGridPositionY = posY;
        // itemDatabase.AddItem(itemToAdd.itemData);

        return true;
    }
    
    public bool AddItem(InventoryItem itemToAdd, int posX, int posY)
    {
        var rt = itemToAdd.GetComponent<RectTransform>();
        rt.SetParent(rectTrans);

        for (var i = 0; i < itemToAdd.itemData.Width; i++)
        {
            for (var j = 0; j < itemToAdd.itemData.Height; j++)
            {
                gridSlots[posX + i, posY + j] = itemToAdd;
            }
        }

        var position = new Vector2
        {
            x = posX * tileSize + tileSize * itemToAdd.itemData.Width / 2,
            y = -(posY * tileSize + tileSize * itemToAdd.itemData.Height / 2)
        };
        rt.localPosition = position;
        
        itemToAdd.itemData.OnGridPositionX = posX;
        itemToAdd.itemData.OnGridPositionY = posY;
        // itemDatabase.AddItem(itemToAdd.itemData);

        return true;
    }
    
    public InventoryItem RemoveItem(int x, int y)
    {
        var toReturn = gridSlots[x, y];
        if (toReturn == null) return null;
        
        // itemDatabase.RemoveItem(toReturn.itemData);
        
        CleanGridReference(toReturn);
        return toReturn;
    }

    private void CleanGridReference(InventoryItem item)
    {
        for (var i = 0; i < item.itemData.Width; i++)
        {
            for (var j = 0; j < item.itemData.Height; j++)
            {
                gridSlots[item.itemData.OnGridPositionX + i, item.itemData.OnGridPositionY + j] = null;
            }
        }
    }

    private bool IsItemOverlap(int posX, int posY, int itemWidth, int itemHeight, ref InventoryItem overlapItem)
    {
        for (var i = 0; i < itemWidth; i++)
        {
            for (var j = 0; j < itemHeight; j++)
            {
                var targetSlot = gridSlots[posX + i, posY + j];
                if (targetSlot != null)
                {
                    if (overlapItem == null) overlapItem = targetSlot;
                    else
                    {
                        if (overlapItem != targetSlot) return true;
                    }
                }
            }
        }
    
        return false;
    }
    
    private bool IsItemOutsideInventory(int posX, int posY, int itemWidth, int itemHeight)
    {
        if (IsPositionOutsideInventory(posX, posY)) return true;
        posX += itemWidth - 1;
        posY += itemHeight - 1;
        if (IsPositionOutsideInventory(posX, posY)) return true;
        return false;
    }
    
    private bool IsPositionOutsideInventory(int posX, int posY)
    {
        if (posX < 0 || posY < 0) return true;
        if (posX >= width || posY >= height) return true;
        return false;
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

    internal Vector2Int GetFirstAvailableSlot(int itemWidth, int itemHeight)
    {
        Vector2Int startPosition = new Vector2Int();
        var cellNeeded = itemWidth * itemHeight;
        var availableCell = 0;
        for (int x = 0, i = 0; x < width; x++)
        {
            for (int y = 0, j = 0; y < height; y++)
            {
                if (i > itemWidth) i = 0;
                if (j > itemHeight) j = 0;
                if (i == 0 && j == 0) startPosition = new Vector2Int(x, y);
                
                // Debug.Log($"grid slot {x}, {y} : {gridSlots[x,y]}");
                
                if (gridSlots[x + i, y + j] == null)
                {
                    availableCell++;
                    i++;
                    j++;
                }
                else
                {
                    i = 0;
                    j = 0;
                    startPosition = new Vector2Int();
                    continue;
                }
                if (availableCell == cellNeeded) break;
            }

            if (availableCell == cellNeeded) break;
        }
        return startPosition;
    }

    internal bool IsGridTileOccupied(Vector2Int targetGridCell) =>
        gridSlots[targetGridCell.x, targetGridCell.y] != null;
}
