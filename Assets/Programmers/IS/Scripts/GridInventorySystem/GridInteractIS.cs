using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// The script is responsible for marking the inventory grid as interactable
/// </summary>
public class GridInteractIS : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private InventoryControllerIS inventoryController;

    private void Awake()
    {
        inventoryController = FindObjectOfType<InventoryControllerIS>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("pointer entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("pointer exited");
    }
}
