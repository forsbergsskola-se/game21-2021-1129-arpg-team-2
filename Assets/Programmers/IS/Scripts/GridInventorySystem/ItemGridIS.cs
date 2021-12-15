using UnityEngine;

/// <summary>
/// The script is responsible for getting the tile position on the inventory grid
/// </summary>

public class ItemGridIS : MonoBehaviour
{
    private const float tileSize = 125f;
    private RectTransform rectTrans;
    private Vector2 positionOnGrid = new Vector2();
    private Vector2Int tileGridPosition = new Vector2Int();

    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();
    }

    internal Vector2Int GetTileGridPosition(Vector2 mousePosition)
    {
        var rectTransPosition = rectTrans.position;
        positionOnGrid.x = mousePosition.x - rectTransPosition.x;
        positionOnGrid.y = rectTransPosition.y - mousePosition.y;

        tileGridPosition.x = (int)(positionOnGrid.x / tileSize);
        tileGridPosition.y = (int)(positionOnGrid.y / tileSize);

        return tileGridPosition;
    }
}
