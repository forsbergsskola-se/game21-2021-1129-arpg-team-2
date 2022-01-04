using UnityEngine;

public class WorldItem : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    public ItemData ItemData => itemData;

    // private void Awake()
    // {
    //     GetComponent<SpriteRenderer>().sprite = itemData.itemIcon;
    // }
}
