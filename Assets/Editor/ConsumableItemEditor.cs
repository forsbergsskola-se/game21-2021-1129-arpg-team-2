using UnityEditor;

[CustomEditor(typeof(ConsumableItem))]
public class ConsumableItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var item = target as ConsumableItem;

        item.ConsumableType = (ConsumableType) EditorGUILayout.EnumPopup("Consumable type <3", item.ConsumableType);
    }
}
