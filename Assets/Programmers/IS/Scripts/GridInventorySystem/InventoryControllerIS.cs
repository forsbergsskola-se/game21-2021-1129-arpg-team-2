using UnityEngine;

/// <summary>
/// The script is responsible for detecting which grid cell is selected
/// </summary>
public class InventoryControllerIS : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] internal ItemGridIS selectedItemGrid;

    private InventoryItemIS selectedItem;
    private RectTransform recTrans;

    private void Update()
    {
        if (selectedItemGrid == null) return;
        if (selectedItem != null) recTrans.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            var tileGridPosition = selectedItemGrid.GetTileGridPosition(Input.mousePosition);
            if (selectedItem == null)
            {
                selectedItem = selectedItemGrid.PickUpItem(tileGridPosition.x, tileGridPosition.y);
                if (selectedItem != null) recTrans = selectedItem.GetComponent<RectTransform>();
            }
            else
            {
                selectedItemGrid.AddItem(selectedItem, tileGridPosition.x, tileGridPosition.y);
                selectedItem = null;
            }
        }
    }
}
