using UnityEngine;

[CreateAssetMenu(fileName = "inventory grid", menuName = "Game/inventory grid")]
public class ItemGridIS : ScriptableObject
{
    [SerializeField] private float tileSize;
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] internal RectTransform rectTrans;
    
    public float TileSize => tileSize;
    public int Width => width;
    public int Height => height;

    private InventoryItemIS[,] gridSlots;

    public void InitGrid()
    {
        gridSlots = new InventoryItemIS[width, height];
        var size = new Vector2(width * tileSize, height * tileSize);
        rectTrans.sizeDelta = size;
    }

    public bool AddItem(InventoryItemIS itemToAdd, int posX, int posY)
    {
        // Boundary and overlap checks should go here later
        
        var rt = itemToAdd.GetComponent<RectTransform>();
        rt.SetParent(rectTrans);

        for (var i = 0; i < itemToAdd.itemData.width; i++)
        {
            for (var j = 0; j < itemToAdd.itemData.height; j++)
            {
                gridSlots[posX + i, posY + j] = itemToAdd;
            }
        }

        itemToAdd.OnGridPositionX = posX;
        itemToAdd.OnGridPositionY = posY;

        var position = new Vector2
        {
            x = posX * tileSize + tileSize * itemToAdd.itemData.width / 2,
            y = -(posY * tileSize + tileSize * itemToAdd.itemData.height / 2)
        };
        rt.localPosition = position;
        return true;
    }
}
