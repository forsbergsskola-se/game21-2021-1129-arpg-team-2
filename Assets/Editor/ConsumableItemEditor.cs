using UnityEditor;

[CustomEditor(typeof(ConsumableItem))]
public class ConsumableItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var item = target as ConsumableItem;
        item.ItemType = (ItemType) EditorGUILayout.EnumPopup("Item type", ItemType.Consumable);
        item.ConsumableType = (ConsumableType) EditorGUILayout.EnumPopup("Consumable type", item.ConsumableType);
    }
}
