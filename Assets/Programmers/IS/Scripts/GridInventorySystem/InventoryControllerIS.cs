using UnityEngine;

/// <summary>
/// The script is responsible for detecting which grid cell is selected
/// </summary>
public class InventoryControllerIS : MonoBehaviour
{
    [SerializeField] private ItemGridIS selectedItemGrid;

    private void Update()
    {
        Debug.Log(selectedItemGrid?.GetTileGridPosition(Input.mousePosition));
    }
}
