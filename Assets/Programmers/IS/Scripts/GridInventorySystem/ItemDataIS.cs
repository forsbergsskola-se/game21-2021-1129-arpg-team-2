using UnityEngine;

[CreateAssetMenu(fileName = "new inventory item", menuName = "Game/item")]
public class ItemDataIS : ScriptableObject
{
    [SerializeField] internal int width;
    [SerializeField] internal int height;
    [SerializeField] internal Sprite itemIcon;
    private bool hasValue;
    public bool HasValue { get => hasValue; set => hasValue = value; }

    public void ResetItemData()
    {
        width = 0;
        height = 0;
        itemIcon = null;
        HasValue = false;
    }
}
