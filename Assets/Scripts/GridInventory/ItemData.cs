using UnityEngine;

/// <summary>
/// Used to hold static values for items; not meant to be changed (most of the time, see comment for method ResetItemData())
/// </summary>

[CreateAssetMenu(fileName = "new inventory item", menuName = "Game/item")]
public class ItemData : ScriptableObject
{
    [SerializeField] internal int width;
    [SerializeField] internal int height;
    [SerializeField] internal Sprite itemIcon;
    private bool hasValue;
    public bool HasValue { get => hasValue; set => hasValue = value; }
    
    private int? worldItemId;
    public int? WorldItemId { get => worldItemId; set => worldItemId = value; }
    
    // NOTE: Only use this when ItemData is used to pass dynamic values around
    public void ResetItemData()
    {
        width = 0;
        height = 0;
        itemIcon = null;
        HasValue = false;
        worldItemId = null;
    }
}
