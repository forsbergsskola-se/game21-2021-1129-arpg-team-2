using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The script is responsible for
/// (1) connecting InventoryItem prefab with Scriptable Object ItemData
/// (2) storing data from ItemData inside ItemClass on individual InventoryItem
/// </summary>
public class InventoryItem : MonoBehaviour
{
    [SerializeField] private ItemGrid grid;
    private ItemDataHolder data;
    private int onGridPositionX;
    private int onGridPositionY;

    public int OnGridPositionX { get => onGridPositionX; set => onGridPositionX = value; }
    public int OnGridPositionY { get => onGridPositionY; set => onGridPositionY = value; }
    public ItemDataHolder ItemData => data;

    public void Set(BaseItem item)
    {
        data = new ItemDataHolder(item);
        
        GetComponent<Image>().sprite = data.ItemIcon;
        var size = new Vector2
        {
            x = data.Width * grid.TileSize,
            y = data.Height * grid.TileSize
        };
        GetComponent<RectTransform>().sizeDelta = size;
    }
}