using UnityEngine;

/// <summary>
/// The script is responsible for detecting which grid cell is selected
/// </summary>
public class InventoryControllerIS : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] internal ItemGridIS selectedItemGrid;

    private InventoryItemIS selectedItem;

    private void Update()
    {
        if (selectedItemGrid == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            var tileGridPosition = selectedItemGrid.GetTileGridPosition(Input.mousePosition);
            if (selectedItem == null)
            {
                selectedItem = selectedItemGrid.PickUpItem(tileGridPosition.x, tileGridPosition.y);
            }
            else
            {
                selectedItemGrid.AddItem(selectedItem, tileGridPosition.x, tileGridPosition.y);
            }
        }
    }
}
