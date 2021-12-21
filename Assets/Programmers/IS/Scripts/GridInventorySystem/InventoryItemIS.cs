using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The script is responsible for
/// (1) connecting InventoryItem prefab with Scriptable Object ItemData
/// (2) storing data from ItemData inside ItemClass on individual InventoryItem
/// </summary>
public class InventoryItemIS : MonoBehaviour
{
    [SerializeField] private ItemGridIS grid;
    private ItemClassIS data;
    private int onGridPositionX;
    private int onGridPositionY;
    private int worldItemId;

    public int OnGridPositionX { get => onGridPositionX; set => onGridPositionX = value; }
    public int OnGridPositionY { get => onGridPositionY; set => onGridPositionY = value; }
    public int WorldItemId => worldItemId;
    public ItemClassIS ItemData => data;

    public void Set(ItemDataIS item)
    {
        data = new ItemClassIS(item.width, item.height, item.itemIcon);
        
        GetComponent<Image>().sprite = data.ItemIcon;
        var size = new Vector2
        {
            x = data.Width * grid.TileSize,
            y = data.Height * grid.TileSize
        };
        GetComponent<RectTransform>().sizeDelta = size;
        // worldItemId = id;
    }
}
