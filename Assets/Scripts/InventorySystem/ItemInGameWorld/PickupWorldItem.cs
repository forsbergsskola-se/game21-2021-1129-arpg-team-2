using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// Allows player to pick up WorldItem through 2 types of commands (right-click OR holding down left ctrl + right-click)
/// Should be attached to an item prefab
/// </summary>

public class PickupWorldItem : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private float distanceFromCamera;
    [SerializeField] private GameObject playerInventory;
    [SerializeField] private GameObject spawner;

    // UnityEvents for picking up and dropping items
    [HideInInspector] public UnityEvent<PickUp> PrepareQuickAdd;
    [HideInInspector] public UnityEvent<PickUp> PrepareRegularAdd;
    
    // Inventory-UI-related
    private GridVisibleController gridVisibleControl;
    private bool isStickToCursor;
    private Camera cam;

    private void Awake()
    {
        gridVisibleControl = FindObjectOfType<GridVisibleController>();
        cam = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && Input.GetKey(KeyCode.LeftControl))
        {
            QuickAdd();
        }
        else if (eventData.button == PointerEventData.InputButton.Right && isStickToCursor) isStickToCursor = false;
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            gridVisibleControl.SetGridVisibility(true);
            isStickToCursor = true;
            transform.LookAt(cam.transform);
            RegularAdd();
        }
    }

    private void QuickAdd()
    {
        var item = GetComponent<WorldItem>().Item;
        PrepareQuickAdd?.Invoke(new PickUp(item, gameObject));
        playerInventory.GetComponent<ItemGridView>().ItemAddSuccess.AddListener(OnItemAddSuccess);
    }

    private void RegularAdd()
    {
        var item = GetComponent<WorldItem>().Item;
        PrepareRegularAdd?.Invoke(new PickUp(item, gameObject));
        playerInventory.GetComponent<ItemGridView>().ItemAddSuccess.AddListener(OnItemAddSuccess);
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

    public void OnItemAddSuccess()
    {
        playerInventory.GetComponent<ItemGridView>().ItemAddSuccess.RemoveListener(OnItemAddSuccess);
        isStickToCursor = false;
        GameObject o;
        (o = gameObject).SetActive(false);
        spawner.GetComponent<CarrotSpawner>().CarrotIsCollected(o);
    }
}

public class PickUp
{
    public BaseItem item;
    public GameObject itemGameObject;

    public PickUp(BaseItem item, GameObject itemGameObject)
    {
        this.item = item;
        this.itemGameObject = itemGameObject;
    }
}
