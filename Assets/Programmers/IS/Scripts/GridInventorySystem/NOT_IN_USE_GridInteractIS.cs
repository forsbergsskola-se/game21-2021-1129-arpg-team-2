using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// NOT IN USE ATM
/// The script is responsible for marking the inventory grid as interactable
/// </summary>

[RequireComponent(typeof(ItemGridIS))]
public class GridInteractIS : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private InventoryControllerIS inventoryController;
    private ItemGridIS itemGrid;

    private void Awake()
    {
        itemGrid = GetComponent<ItemGridIS>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("pointer entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("pointer exited");
        inventoryController.selectedItemGrid = null;
    }
}
