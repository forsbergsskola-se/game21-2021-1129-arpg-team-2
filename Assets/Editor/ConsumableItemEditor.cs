// using UnityEditor;
//
// [CustomEditor(typeof(ConsumableItem))]
// public class ConsumableItemEditor : Editor
// {
//     private SerializedObject so;
//     private SerializedProperty isPerishable;
//     private SerializedProperty expirationInSeconds;
//
//     private void OnEnable()
//     {
//         so = serializedObject;
//         isPerishable = so.FindProperty("isPerishable");
//         expirationInSeconds = so.FindProperty("expirationInSeconds");
//     }
//
//     public override void OnInspectorGUI()
//     {
//         base.OnInspectorGUI();
//         so.Update();
//         EditorGUILayout.PropertyField(isPerishable);
//         if (isPerishable.boolValue) EditorGUILayout.PropertyField(expirationInSeconds);
//         so.ApplyModifiedProperties();
//
//         var c = target as ConsumableItem;
//         EditorUtility.SetDirty(c);
//     }
// }
