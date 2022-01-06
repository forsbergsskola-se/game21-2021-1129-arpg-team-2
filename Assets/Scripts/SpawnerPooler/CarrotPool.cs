using UnityEngine;

public class CarrotPool : MonoBehaviour
{
    [SerializeField] private PoolScriptableObject pool;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int size;
    private void Awake()
    {
        pool.Prefab = objectToPool;
        pool.Size = size;
        pool.Load();
    }

    public GameObject Pop() => pool.Pop();
}
