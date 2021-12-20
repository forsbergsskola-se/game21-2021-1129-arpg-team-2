using UnityEngine;
using UnityEngine.EventSystems;

public class GridVisibleControllerIS : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ItemGridViewIS gridView;

    public void OnPointerDown(PointerEventData eventData)
    {
        ToggleItemGrid();
    }

    public void ToggleItemGrid() => gridView.transform.gameObject.SetActive(!gridView.transform.gameObject.activeInHierarchy);
    public void SetGridVisibility(bool isVisible) => gridView.transform.gameObject.SetActive(isVisible);
}
