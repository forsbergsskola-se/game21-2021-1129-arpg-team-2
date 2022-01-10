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
    public ItemData itemData;

    public void Set(int width, int height, Sprite itemIcon, ItemType type, int? subType)
    {
        var size = new Vector2
        {
            x = width * grid.TileSize,
            y = height * grid.TileSize
        };
        itemData = new ItemData(width, height, itemIcon, type, subType);
        GetComponent<Image>().sprite = itemData.ItemIcon;
        GetComponent<RectTransform>().sizeDelta = size;
    }
}
