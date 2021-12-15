using UnityEngine;
using UnityEngine.UI;

public class InventoryItemIS : MonoBehaviour
{
    [SerializeField] private ItemDataIS itemData;

    public void Set(ItemDataIS item)
    {
        itemData = item;
        GetComponent<Image>().sprite = itemData.itemIcon;
    }
}
