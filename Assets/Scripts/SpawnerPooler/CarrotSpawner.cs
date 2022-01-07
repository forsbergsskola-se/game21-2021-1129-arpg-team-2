using UnityEngine;
using Random = UnityEngine.Random;

public class CarrotSpawner : MonoBehaviour
{
    [SerializeField] private int maxCarrotDrop = 5;
    [SerializeField] private PoolScriptableObject carrotPool;
    [SerializeField] private GameObject playerInventory;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, 1.32f, 0);
    }
    
    public void SpawnFromPool()
    {
        int randomNum = Random.Range(1, maxCarrotDrop +1);
        for (var i = 0; i < randomNum; i++)
        {
            if (carrotPool != null)
            {
                var tempCarrot = carrotPool.pool.Pop();
                tempCarrot.GetComponent<PickupWorldItem>().PrepareQuickAdd.AddListener(playerInventory.GetComponent<ItemGridView>().OnPrepareQuickAdd);
                tempCarrot.GetComponent<PickupWorldItem>().PrepareRegularAdd.AddListener(playerInventory.GetComponent<ItemGridView>().OnPrepareRegularAdd);
                tempCarrot.SetActive(true);
                tempCarrot.GetComponent<WorldItem>().StartExpirationCountDown();
                tempCarrot.transform.position = transform.position + offset;
            }
        }
    }

    public void ReturnToPool(GameObject carrot) => carrotPool.pool.Push(carrot);
}