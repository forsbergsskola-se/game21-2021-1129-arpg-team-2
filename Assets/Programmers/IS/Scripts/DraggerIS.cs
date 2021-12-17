using UnityEngine;
using UnityEngine.EventSystems;

public class DraggerIS : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
    private RectTransform rectTrans;

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("dragging");
        rectTrans.anchoredPosition += eventData.delta;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin dragging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("stopped dragging");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("being clicked from OnPointerDown");
    }
}
