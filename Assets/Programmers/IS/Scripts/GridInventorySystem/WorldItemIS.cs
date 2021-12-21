using UnityEngine;

public class WorldItemIS : MonoBehaviour
{
    [SerializeField] private ItemDataIS itemData;
    public ItemDataIS ItemData => itemData;

    private void Awake()
    {
        Debug.Log("Instance ID from WorldItem: " + gameObject.GetInstanceID());
        GetComponent<SpriteRenderer>().sprite = itemData.itemIcon;
    }
}
