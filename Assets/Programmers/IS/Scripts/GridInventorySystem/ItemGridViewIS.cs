using UnityEditor.Search;
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
    // tileSize needs to match the actual size of the slot asset in use
    // internal const float tileSize = 125;
    // [SerializeField] private int gridWidth;
    // [SerializeField] private int gridLength;
    // private RectTransform rectTrans;
    [SerializeField] private ItemGridIS grid;
    private Vector2 positionOnGrid = new Vector2();
    private Vector2Int tileGridPosition = new Vector2Int();
    private InventoryItemIS[,] inventoryItemSlots;
    private InventoryControllerIS inventoryController;

    private void Awake()
    {
        grid.rectTrans = GetComponent<RectTransform>();
        grid.InitGrid();
        inventoryController = FindObjectOfType<InventoryControllerIS>();
    }

    // public void InitGrid(int width, int length)
    // {
    //     inventoryItemSlots = new InventoryItemIS[width, length];
    //     Vector2 size = new Vector2(width * tileSize, length * tileSize);
    //     rectTrans.sizeDelta = size;
    // }

    internal Vector2Int GetTileGridPosition(Vector2 mousePosition)
    {
        var rectTransPosition = grid.rectTrans.position;
        positionOnGrid.x = mousePosition.x - rectTransPosition.x;
        positionOnGrid.y = rectTransPosition.y - mousePosition.y;

        tileGridPosition.x = (int)(positionOnGrid.x / grid.TileSize);
        tileGridPosition.y = (int)(positionOnGrid.y / grid.TileSize);

        return tileGridPosition;
    }

    // public bool AddItem(InventoryItemIS itemToAdd, int posX, int posY, ref InventoryItemIS overlapItem)
    // {
    //     if (IsOutsideBoundary(posX, posY, itemToAdd.itemData.width, itemToAdd.itemData.height)) return false;
    //     
    //     if (!OverlapCheck(posX, posY, itemToAdd.itemData.width, itemToAdd.itemData.height, ref overlapItem))
    //     {
    //         overlapItem = null;
    //         return false;
    //     }
    //     
    //     if (overlapItem != null) CleanGridReference(overlapItem);
    //
    //     var rt = itemToAdd.GetComponent<RectTransform>();
    //     rt.SetParent(rectTrans);
    //     
    //     for (int i = 0; i < itemToAdd.itemData.width; i++)
    //     {
    //         for (int j = 0; j < itemToAdd.itemData.height; j++)
    //         {
    //             inventoryItemSlots[posX + i, posY + j] = itemToAdd;
    //         }
    //     }
    //
    //     itemToAdd.onGridPositionX = posX;
    //     itemToAdd.onGridPositionY = posY;
    //
    //     Vector2 position = new Vector2
    //     {
    //         x = posX * tileSize + tileSize * itemToAdd.itemData.width / 2,
    //         y = -(posY * tileSize + tileSize * itemToAdd.itemData.height / 2)
    //     };
    //
    //     rt.localPosition = position;
    //     return true;
    // }

    private bool OverlapCheck(int posX, int posY, int width, int length, ref InventoryItemIS overlapItem)
    {
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < length; j++)
            {
                var targetSlot = inventoryItemSlots[posX + i, posY + j];
                if (targetSlot != null)
                {
                    if (overlapItem == null) overlapItem = targetSlot;
                    else
                    {
                        if (overlapItem != targetSlot) return false;
                    }
                }
            }
        }

        return true;
    }

    public InventoryItemIS PickUpItem(int x, int y)
    {
        var toReturn = inventoryItemSlots[x, y];

        if (toReturn == null) return null;

        CleanGridReference(toReturn);
        
        return toReturn;
    }

    private void CleanGridReference(InventoryItemIS item)
    {
        for (int i = 0; i < item.itemData.width; i++)
        {
            for (int j = 0; j < item.itemData.height; j++)
            {
                inventoryItemSlots[item.OnGridPositionX + i, item.OnGridPositionY + j] = null;
            }
        }
    }

    // private bool PositionCheck(int posX, int posY)
    // {
    //     if (posX < 0 || posY < 0) return false;
    //     if (posX >= gridWidth || posY >= gridLength) return false;
    //     return true;
    // }

    // private bool IsOutsideBoundary(int posX, int posY, int width, int length)
    // {
    //     if (!PositionCheck(posX, posY)) return true;
    //     posX += width - 1;
    //     posY += length - 1;
    //     if (!PositionCheck(posX, posY)) return true;
    //     return false;
    // }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item dropped inside inventory!");
        if (eventData.pointerDrag != null)
        {
            tileGridPosition = GetTileGridPosition(Input.mousePosition);
            // inventoryController.selectedItem = eventData.pointerDrag.GetComponent<InventoryItemIS>();
            // inventoryController.PlaceItem(tileGridPosition);
            
            // var itemToAdd = eventData.pointerDrag.GetComponent<InventoryItemIS>();
            // grid.AddItem(itemToAdd, tileGridPosition.x, tileGridPosition.y);
            Debug.Log(tileGridPosition);
        }
    }
}
