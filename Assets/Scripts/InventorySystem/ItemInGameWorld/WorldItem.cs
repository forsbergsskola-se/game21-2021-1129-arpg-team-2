using UnityEngine;

public class WorldItem : MonoBehaviour
{
    [SerializeField] private BaseItem item;
    public BaseItem Item => item;

    [SerializeField] private PoolScriptableObject objectPool;

    // public void StartExpirationCountDown()
    // {
    //     if (item is ConsumableItem c && c && c.IsPerishable) Invoke(nameof(Expire), c.ExpirationInSeconds);
    // }

    private void Expire()
    {
        if (!gameObject.activeInHierarchy) return;
        GameObject o;
        (o = gameObject).SetActive(false);
        objectPool.Push(o);
    }
}
