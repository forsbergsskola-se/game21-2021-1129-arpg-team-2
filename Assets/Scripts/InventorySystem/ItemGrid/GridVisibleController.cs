using UnityEngine;
using UnityEngine.EventSystems;

public class GridVisibleController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ItemGridView gridView;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) ToggleItemGrid();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) ToggleItemGrid();
    }

    public void ToggleItemGrid() => gridView.transform.gameObject.SetActive(!gridView.transform.gameObject.activeInHierarchy);
    public void SetGridVisibility(bool isVisible) => gridView.transform.gameObject.SetActive(isVisible);
}
