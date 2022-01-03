using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Weapon))]
public class WeaponEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var weapon = target as Weapon;

        if (weapon.Ranged)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Projectile");
            weapon.Projectile = (GameObject) EditorGUILayout.ObjectField(weapon.Projectile, typeof(GameObject), false);
            EditorGUILayout.EndHorizontal();
        }
    }
}
