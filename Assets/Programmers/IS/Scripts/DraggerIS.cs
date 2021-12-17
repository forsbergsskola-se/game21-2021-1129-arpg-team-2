using UnityEngine;
using UnityEngine.EventSystems;

public class DraggerIS : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
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
        Debug.Log("dragging");
        rectTrans.anchoredPosition += eventData.delta;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin dragging");
        canvasGroup.alpha = .6f; // item appears transparent while being dragged
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("stopped dragging");
        canvasGroup.alpha = 1f; // back to one upon finishing dragging
        canvasGroup.blocksRaycasts = true;
    }
}
