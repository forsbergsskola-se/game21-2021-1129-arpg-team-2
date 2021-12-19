using UnityEngine;
using UnityEngine.EventSystems;

public class SetSelectedItemGridIS : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ItemGridIS grid;
    [SerializeField] private ItemGridViewIS gridView;
    
    // for development only, NOT final
    // [SerializeField] private List<ItemDataIS> itemList;
    // [SerializeField] private GameObject itemPrefab;
    // for development only, NOT final

    public void OnPointerDown(PointerEventData eventData)
    {
        ToggleItemGrid();
        // CreateRandomItem();
    }

    // private void CreateRandomItem()
    // {
    //     var item = Instantiate(itemPrefab).GetComponent<InventoryItemIS>();
    //     item.Set(itemList[0]);
    //     grid.AddItem(item, 0, 1);
    // }

    private void ToggleItemGrid() => gridView.transform.gameObject.SetActive(!gridView.transform.gameObject.activeInHierarchy);
}
