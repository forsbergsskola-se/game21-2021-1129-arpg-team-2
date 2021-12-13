using System.Collections.Generic;
using UnityEngine;

public class InventoryIS
{
    private List<ItemIS> itemList;

    public InventoryIS()
    {
        itemList = new List<ItemIS>();
    }

    public void AddItem(ItemIS item)
    {
        itemList.Add(item);
        Debug.Log("What's in the inventory: ");
        foreach (var i in itemList)
        {
            Debug.Log($"Item - { i.ItemName }");
        }
    }
    public void RemoveItem(ItemIS item) => itemList.Remove(item);
}
