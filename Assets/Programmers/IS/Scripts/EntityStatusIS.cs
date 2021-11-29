using UnityEngine;

public enum EntityStatus
{
    Intact,
    Damaged,
    Destroyed
}

[CreateAssetMenu(fileName = "EntityStatus", menuName = "Value/EntityStatus")]
public class EntityStatusIS : ScriptableObject
{
    [SerializeField] private EntityStatus entityStatus;
}
