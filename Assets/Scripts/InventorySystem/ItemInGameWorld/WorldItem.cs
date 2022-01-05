using UnityEngine;

public class WorldItem : MonoBehaviour
{
    [SerializeField] private BaseItem item;
    public BaseItem Item => item;
}
