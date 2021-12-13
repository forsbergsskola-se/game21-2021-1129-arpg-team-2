using System;
using UnityEngine;

public class PlayerInventoryIS : MonoBehaviour
{
    private InventoryIS inventory;
    private void Awake()
    {
        inventory = new InventoryIS();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ItemInWorldIS itemInWorld))
        {
            Debug.Log("Touched an item of some sort!");
            itemInWorld.transform.gameObject.SetActive(false);
            inventory.AddItem(itemInWorld.Item);
        }
        else Debug.Log("That was not an item to pick up or consume");
    }
}
