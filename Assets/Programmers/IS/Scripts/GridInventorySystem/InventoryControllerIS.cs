using UnityEngine;

/// <summary>
/// The script is responsible for detecting which grid cell is selected
/// </summary>
public class InventoryControllerIS : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] internal ItemGridIS selectedItemGrid;

    private void Update()
    {
        if (selectedItemGrid == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(selectedItemGrid.GetTileGridPosition(Input.mousePosition));
        }
    }
}
