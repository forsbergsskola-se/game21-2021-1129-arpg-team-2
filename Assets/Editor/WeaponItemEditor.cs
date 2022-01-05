using UnityEditor;

[CustomEditor(typeof(WeaponItem))]
public class WeaponItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var item = target as WeaponItem;
        item.ItemType = (ItemType) EditorGUILayout.EnumPopup("Item type", ItemType.Weapon);
        item.WeaponType = (WeaponType) EditorGUILayout.EnumPopup("Weapon type", item.WeaponType);
    }
}
