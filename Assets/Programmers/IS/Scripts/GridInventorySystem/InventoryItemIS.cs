using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The script is responsible for connecting item prefab with Scriptable Object ItemDataIS
/// </summary>
public class InventoryItemIS : MonoBehaviour
{
    [SerializeField] private ItemGridIS grid;
    [SerializeField] internal ItemDataIS itemData;
    private int onGridPositionX;
    private int onGridPositionY;

    public int OnGridPositionX { get => onGridPositionX; set => onGridPositionX = value; }
    public int OnGridPositionY { get => onGridPositionY; set => onGridPositionY = value; }

    public void Set(ItemDataIS item)
    {
        itemData = item;
        GetComponent<Image>().sprite = itemData.itemIcon;
        var size = new Vector2
        {
            x = itemData.width * grid.TileSize,
            y = itemData.height * grid.TileSize
        };
        GetComponent<RectTransform>().sizeDelta = size;
    }
}
