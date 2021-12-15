using UnityEngine;
using UnityEngine.UI;

public class InventoryItemIS : MonoBehaviour
{
    [SerializeField] private ItemDataIS itemData;

    public void Set(ItemDataIS item)
    {
        itemData = item;
        GetComponent<Image>().sprite = itemData.itemIcon;
        var size = new Vector2
        {
            x = itemData.width * ItemGridIS.tileSize,
            y = itemData.length * ItemGridIS.tileSize
        };
        GetComponent<RectTransform>().sizeDelta = size;
    }
}
