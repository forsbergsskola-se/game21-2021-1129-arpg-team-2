using UnityEngine;

/// <summary>
/// This script is for demo-purpose only.
/// Should retire this asap.
/// </summary>
public class GiveMainQuestItem : MonoBehaviour
{
    [SerializeField] private QuestItem questItem;
    [SerializeField] private ItemGrid playerInventory;
    [SerializeField] private InventoryItem inventoryItemPrefab;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        player.GetComponent<RequestMainQuestItem>().PlayerRequestMainQuestItem.AddListener(AddMainQuestItemToInventory);
    }

    private void AddMainQuestItemToInventory()
    {
        // NOTE: Currently it doesn't check for if player's already acquired the quest item
        var item = Instantiate(inventoryItemPrefab);
        item.GetComponent<InventoryItem>().Set(questItem);

        var firstEmptySlot = playerInventory.GetFirstAvailableSlot(item.itemData.Width, item.itemData.Height);

        var success = playerInventory.AddItem(item, firstEmptySlot.x, firstEmptySlot.y);
        Debug.Log("Adding item successful: " + success);
    }
}
