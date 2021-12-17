using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "new inventory item", menuName = "Game/item")]
public class ItemDataIS : ScriptableObject
{
    [SerializeField] internal int width;
    [FormerlySerializedAs("length")] [SerializeField] internal int height;
    [SerializeField] internal Sprite itemIcon;
}
