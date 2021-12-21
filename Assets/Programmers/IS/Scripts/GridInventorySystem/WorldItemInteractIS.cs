using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Controls how WorldItem interacts with event and/or user input
/// </summary>

public class WorldItemInteractIS : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private float distanceFromCamera;
    [SerializeField] private ItemDataIS pickedUpItem;
    [SerializeField] private ItemGridViewIS grid;
    [SerializeField] private GameObjectIdListValue pickedUpWorldItemIds;

    private GridVisibleControllerIS gridVisibleControl;
    private bool isStickToCursor;
    private Camera cam;

    private void Awake()
    {
        gridVisibleControl = FindObjectOfType<GridVisibleControllerIS>();
        cam = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && Input.GetKey(KeyCode.LeftControl))
        {
            UpdatePickedUpItemData();
            grid.OnQuickAdd();
        }
        else
        {
            gridVisibleControl.SetGridVisibility(true);
            isStickToCursor = true;
            transform.LookAt(cam.transform);
            UpdatePickedUpItemData();
        }
    }

    private void UpdatePickedUpItemData()
    {
        var currentItem = GetComponent<WorldItemIS>().ItemData;
        pickedUpItem.height = currentItem.height;
        pickedUpItem.width = currentItem.width;
        pickedUpItem.itemIcon = currentItem.itemIcon;
        pickedUpItem.HasValue = true;
        pickedUpItem.WorldItemId = gameObject.GetInstanceID();
    }

    private void Update()
    {
        if (isStickToCursor) ItemStickToCursor();
    }

    private void ItemStickToCursor()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = cam.nearClipPlane + distanceFromCamera;
        var mouseWorldPos = cam.ScreenToWorldPoint(mousePos);
        transform.position = mouseWorldPos;
    }

    public void OnItemAddedSuccess()
    {
        var entry = new GameObjectIdClass(gameObject);
        pickedUpWorldItemIds.AddToList(entry);
        gameObject.SetActive(false);
    }
}
