using UnityEngine;

public class WorldItemIS : MonoBehaviour
{
    // [SerializeField] private GameObject inventoryItemPrefab;
    [SerializeField] private ItemDataIS itemData;
    public ItemDataIS ItemData => itemData;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = itemData.itemIcon;
        // inventoryItemPrefab.GetComponent<InventoryItemIS>().Set(itemData);
    }
}
