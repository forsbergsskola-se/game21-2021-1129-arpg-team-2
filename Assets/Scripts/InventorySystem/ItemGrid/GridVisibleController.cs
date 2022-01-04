using UnityEngine;
using UnityEngine.EventSystems;

public class GridVisibleController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ItemGridView gridView;

    public void OnPointerDown(PointerEventData eventData)
    {
        ToggleItemGrid();
    }

    public void ToggleItemGrid() => gridView.transform.gameObject.SetActive(!gridView.transform.gameObject.activeInHierarchy);
    public void SetGridVisibility(bool isVisible) => gridView.transform.gameObject.SetActive(isVisible);
}
