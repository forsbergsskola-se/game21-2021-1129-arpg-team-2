using System.Collections;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    [SerializeField] private BaseItem item;
    public BaseItem Item => item;

    [SerializeField] private PoolScriptableObject carrotPool;

    private void Start()
    {
    }
}
