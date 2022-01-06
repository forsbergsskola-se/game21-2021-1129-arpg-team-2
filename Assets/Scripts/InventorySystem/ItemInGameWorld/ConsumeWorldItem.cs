using UnityEngine;
using UnityEngine.EventSystems;

public class ConsumeWorldItem : MonoBehaviour, IPointerDownHandler
{
    private Health playerHealth;
    private IConsumable consumableSelf;

    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        consumableSelf = GetComponent<WorldItem>().Item as IConsumable;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        WorldItem worldItem;
        if (eventData.button == PointerEventData.InputButton.Left &&
            Input.GetKey(KeyCode.LeftControl) && 
            eventData.pointerPressRaycast.gameObject.TryGetComponent(out worldItem) &&
            worldItem.Item is ConsumableItem)
        {
            PlayerConsumeConsumable();
        }
    }

    public void PlayerConsumeConsumable()
    {
        playerHealth.Consume(consumableSelf);
        gameObject.SetActive(false);
    }
}
