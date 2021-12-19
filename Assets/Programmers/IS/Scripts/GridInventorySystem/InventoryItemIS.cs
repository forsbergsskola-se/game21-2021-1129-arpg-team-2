using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The script is responsible for connecting item prefab with Scriptable Object ItemDataIS
/// </summary>
public class InventoryItemIS : MonoBehaviour
{
    [SerializeField] internal ItemDataIS itemData;

    public int onGridPositionX;
    public int onGridPositionY;

    public void Set(ItemDataIS item)
    {
        itemData = item;
        GetComponent<Image>().sprite = itemData.itemIcon;
        var size = new Vector2
        {
            x = itemData.width * ItemGridIS.tileSize,
            y = itemData.height * ItemGridIS.tileSize
        };
        GetComponent<RectTransform>().sizeDelta = size;
    }
}
