using UnityEngine;

public class GameObjectIdClass
{
    internal GameObject worldItem;
    internal int id;

    public GameObjectIdClass(GameObject worldItem)
    {
        this.worldItem = worldItem;
        id = this.worldItem.GetInstanceID();
    }
}
