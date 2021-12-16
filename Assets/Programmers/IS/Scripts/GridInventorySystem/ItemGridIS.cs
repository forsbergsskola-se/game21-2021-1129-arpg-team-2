using UnityEngine;

/// <summary>
/// The script controls
/// (1) the size of the grid
/// (2) initiating the grid
/// (3) adding/picking up item from the grid
/// </summary>

public class ItemGridIS : MonoBehaviour
{
    // tileSize needs to match the actual size of the slot asset in use
    internal const float tileSize = 125;
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridLength;
    // [SerializeField] private GameObject inventoryItem;
    private RectTransform rectTrans;
    private Vector2 positionOnGrid = new Vector2();
    private Vector2Int tileGridPosition = new Vector2Int();
    private InventoryItemIS[,] inventoryItemSlots;

    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        InitGrid(gridWidth, gridLength);
        // var item = Instantiate(inventoryItem).GetComponent<InventoryItemIS>();
        // AddItem(item, 3, 1);
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

    internal bool AddItem(InventoryItemIS itemToAdd, int posX, int posY)
    {
        if (!BoundaryCheck(posX, posY, itemToAdd.itemData.width, itemToAdd.itemData.length)) return false;
        var rt = itemToAdd.GetComponent<RectTransform>();
        rt.SetParent(rectTrans);
        for (int i = 0; i < itemToAdd.itemData.width; i++)
        {
            for (int j = 0; j < itemToAdd.itemData.length; j++)
            {
                inventoryItemSlots[posX + i, posY + j] = itemToAdd;
            }
        }

        itemToAdd.onGridPositionX = posX;
        itemToAdd.onGridPositionY = posY;

        Vector2 position = new Vector2
        {
            x = posX * tileSize + tileSize * itemToAdd.itemData.width / 2,
            y = -(posY * tileSize + tileSize * itemToAdd.itemData.length / 2)
        };

        rt.localPosition = position;
        return true;
    }

    public InventoryItemIS PickUpItem(int x, int y)
    {
        var toReturn = inventoryItemSlots[x, y];

        if (toReturn == null) return null;

        for (int i = 0; i < toReturn.itemData.width; i++)
        {
            for (int j = 0; j < toReturn.itemData.length; j++)
            {
                inventoryItemSlots[toReturn.onGridPositionX + i, toReturn.onGridPositionY + j] = null;
            }
        }
        
        return toReturn;
    }

    private bool PositionCheck(int posX, int posY)
    {
        if (posX < 0 || posY < 0) return false;
        if (posX >= gridWidth || posY >= gridLength) return false;
        return true;
    }

    private bool BoundaryCheck(int posX, int posY, int width, int length)
    {
        if (!PositionCheck(posX, posY)) return false;
        posX += width - 1;
        posY += length - 1;
        if (!PositionCheck(posX, posY)) return false;
        return true;
    }
}
