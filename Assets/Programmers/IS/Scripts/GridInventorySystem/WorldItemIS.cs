using UnityEngine;

public class WorldItemIS : MonoBehaviour
{
    [SerializeField] private ItemDataIS itemData;
    public ItemDataIS ItemData => itemData;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = itemData.itemIcon;
    }
}
