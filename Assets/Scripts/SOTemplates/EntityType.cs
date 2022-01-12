using UnityEngine;

/// <summary>
/// This SO acting as enums for EntityType; to add more EntityType, simply add the new entity type
/// to enum EntityType and the new option will be available in the editor.
/// </summary>

enum entityType
{
    Enemy,
    Destructible
}
[CreateAssetMenu(fileName = "EntityType", menuName = "Value/EntityType")]
public class EntityType : ScriptableObject
{
    [SerializeField] private entityType entityType;
}
