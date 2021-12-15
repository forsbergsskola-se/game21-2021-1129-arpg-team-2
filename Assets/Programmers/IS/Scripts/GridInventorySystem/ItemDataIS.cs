using UnityEngine;

[CreateAssetMenu(fileName = "new inventory item", menuName = "Game/item")]
public class ItemDataIS : ScriptableObject
{
    [SerializeField] private int width;
    [SerializeField] private int length;
    [SerializeField] internal Sprite itemIcon;
}
