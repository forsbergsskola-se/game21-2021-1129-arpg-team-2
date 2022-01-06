using System;
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

    // Action to emit
    // public Action<BaseItem> WorldItemChosen;
    public UnityEvent<BaseItem> WorldItemChosen;
    public UnityEvent<GameObject> GameObjectChosen;
    
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
            UpdatePickedUpItemData();
            playerInventory.GetComponent<ItemGridView>().OnQuickAdd();
        }
        else if (eventData.button == PointerEventData.InputButton.Right && isStickToCursor) isStickToCursor = false;
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            gridVisibleControl.SetGridVisibility(true);
            isStickToCursor = true;
            transform.LookAt(cam.transform);
            UpdatePickedUpItemData();
        }
    }

    private void UpdatePickedUpItemData()
    {
        var currentItem = GetComponent<WorldItem>().Item;
        WorldItemChosen?.Invoke(currentItem);
        GameObjectChosen?.Invoke(gameObject);
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
        isStickToCursor = false;
        GameObject o;
        (o = gameObject).SetActive(false);
        spawner.GetComponent<CarrotSpawner>().CarrotIsCollected(o);
    }
}
