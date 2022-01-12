using UnityEngine;

public enum EntityStatusEnum
{
    Intact,
    Damaged,
    Destroyed
}

[CreateAssetMenu(fileName = "EntityStatus", menuName = "Value/EntityStatus")]
public class EntityStatus : ScriptableObject
{
    [SerializeField] private EntityStatusEnum entityStatus;
}
