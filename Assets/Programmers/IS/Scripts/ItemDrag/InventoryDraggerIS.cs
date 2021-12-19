using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDraggerIS : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTrans;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition += eventData.delta;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f; // item appears transparent while being dragged
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f; // back to one upon finishing dragging
        canvasGroup.blocksRaycasts = true;
    }
}
