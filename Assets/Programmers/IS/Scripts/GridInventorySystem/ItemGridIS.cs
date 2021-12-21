using UnityEngine;

/// <summary>
/// This scriptable object
/// (1) stores configuration on the item grid
/// (2) controls adding and removing logic and validation of doing so
/// </summary>

[CreateAssetMenu(fileName = "inventory grid", menuName = "Game/inventory grid")]
public class ItemGridIS : ScriptableObject
{
    [Header("Grid configuration")]
    [Header("Tile size NEEDS to match the exact size of the square tile used in pixel")]
    [SerializeField] private float tileSize;
    [SerializeField] private int width;
    [SerializeField] private int height;
    internal RectTransform rectTrans;
    
    public float TileSize => tileSize;
    public int Width => width;
    public int Height => height;

    private InventoryItemIS[,] gridSlots;
    private InventoryItemIS overlapItem;
    private InventoryItemIS selectedItem;
    private Vector2 positionOnGrid;
    private Vector2Int tileGridPosition;

    public void InitGrid()
    {
        gridSlots = new InventoryItemIS[width, height];
        var size = new Vector2(width * tileSize, height * tileSize);
        rectTrans.sizeDelta = size;
    }

    public bool AddItem(InventoryItemIS itemToAdd, int posX, int posY)
    {
        
        if (IsItemOutsideInventory(posX, posY, itemToAdd.ItemData.Width, itemToAdd.ItemData.Height)) return false;
        
        if (IsItemOverlap(posX, posY, itemToAdd.ItemData.Width, itemToAdd.ItemData.Height))
        {
            overlapItem = null;
            return false;
        }
        if (overlapItem != null) CleanGridReference(overlapItem);
        
        var rt = itemToAdd.GetComponent<RectTransform>();
        rt.SetParent(rectTrans);

        for (var i = 0; i < itemToAdd.ItemData.Width; i++)
        {
            for (var j = 0; j < itemToAdd.ItemData.Height; j++)
            {
                gridSlots[posX + i, posY + j] = itemToAdd;
            }
        }

        itemToAdd.OnGridPositionX = posX;
        itemToAdd.OnGridPositionY = posY;

        var position = new Vector2
        {
            x = posX * tileSize + tileSize * itemToAdd.ItemData.Width / 2,
            y = -(posY * tileSize + tileSize * itemToAdd.ItemData.Height / 2)
        };
        rt.localPosition = position;


        Debug.Log($"grid slot {posX}, {posY}");
        Debug.Log("width: " + gridSlots[posX, posY].ItemData.Width);
        Debug.Log("width: " + gridSlots[posX, posY].ItemData.Height);
        
        return true;
    }
    
    public InventoryItemIS RemoveItem(int x, int y)
    {
        var toReturn = gridSlots[x, y];
        if (toReturn == null) return null;
        CleanGridReference(toReturn);
        return toReturn;
    }

    private void CleanGridReference(InventoryItemIS item)
    {
        for (var i = 0; i < item.ItemData.Width; i++)
        {
            for (var j = 0; j < item.ItemData.Height; j++)
            {
                gridSlots[item.OnGridPositionX + i, item.OnGridPositionY + j] = null;
            }
        }
    }

    private bool IsItemOverlap(int posX, int posY, int itemWidth, int itemHeight)
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
}
