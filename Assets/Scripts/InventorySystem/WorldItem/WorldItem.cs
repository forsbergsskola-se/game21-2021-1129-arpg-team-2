using UnityEngine;

public class WorldItem : MonoBehaviour
{
    [SerializeField] private ConsumableItemData consumableItemData;
    public ConsumableItemData ConsumableItemData => consumableItemData;
}
