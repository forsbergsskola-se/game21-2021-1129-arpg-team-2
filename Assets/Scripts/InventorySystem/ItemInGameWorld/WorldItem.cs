using UnityEngine;

public class WorldItem : MonoBehaviour
{
    [SerializeField] private ConsumableItem item;
    public ConsumableItem Item => item;
}
