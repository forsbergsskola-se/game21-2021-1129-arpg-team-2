using UnityEngine;

[CreateAssetMenu(fileName = "new inventory item", menuName = "Game/item")]
public class ItemDataIS : ScriptableObject
{
    [SerializeField] internal int width;
    [SerializeField] internal int length;
    [SerializeField] internal Sprite itemIcon;
}
