using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    
    [SerializeField] private int maxPotionDrop = 5;
    [SerializeField] private PoolScriptableObject potionPool;
    [SerializeField] private GameObject playerInventory;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, 1.32f, 0);
    }
    
    public void SpawnFromPool()
    {
        int randomNum = Random.Range(1, maxPotionDrop +1);
        for (var i = 0; i < randomNum; i++)
        {
            if (potionPool != null)
            {
                var tempCarrot = potionPool.pool.Pop();
                tempCarrot.GetComponent<PickupWorldItem>().PrepareQuickAdd.AddListener(playerInventory.GetComponent<ItemGridView>().OnPrepareQuickAdd);
                tempCarrot.GetComponent<PickupWorldItem>().PrepareRegularAdd.AddListener(playerInventory.GetComponent<ItemGridView>().OnPrepareRegularAdd);
                tempCarrot.SetActive(true);
                tempCarrot.GetComponent<WorldItem>().StartExpirationCountDown();
                tempCarrot.transform.position = transform.position + offset;
            }
        }
    }

    public void ReturnToPool(GameObject carrot) => potionPool.pool.Push(carrot);
}
