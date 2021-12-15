using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// The script is responsible for marking the inventory grid as interactable
/// </summary>

[RequireComponent(typeof(ItemGridIS))]
public class GridInteractIS : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private InventoryControllerIS inventoryController;
    private ItemGridIS itemGrid;

    private void Awake()
    {
        inventoryController = FindObjectOfType<InventoryControllerIS>();
        itemGrid = GetComponent<ItemGridIS>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("pointer entered");
        inventoryController.selectedItemGrid = itemGrid;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("pointer exited");
        inventoryController.selectedItemGrid = null;
    }
}
