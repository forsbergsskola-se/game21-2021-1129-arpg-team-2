using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryIS : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private List<ItemIS> itemList;
    [SerializeField] private ItemIS itemToAdd;
    [SerializeField] private ItemIS itemToRemove;
    private GameObject[] slotList;

    private void Start()
    {
        var slotHolderLength = slotHolder.transform.childCount;
        slotList = new GameObject[slotHolderLength];
        for (var i = 0; i < slotHolderLength; i++)
            slotList[i] = slotHolder.transform.GetChild(i).gameObject;
        
        RefreshUI();
        Add(itemToAdd);
    }

    public void RefreshUI()
    {
        for (var i = 0; i < slotList.Length; i++)
        {
            try
            {
                slotList[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slotList[i].transform.GetChild(0).GetComponent<Image>().sprite = itemList[i].ItemIcon;
                slotList[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "0";
            }
            catch (Exception e)
            {
                slotList[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slotList[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slotList[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }

    public void Add(ItemIS item)
    {
        itemList.Add(item);
        RefreshUI();
    }

    public void Remove(ItemIS item)
    {
        itemList.Remove(item);
        RefreshUI();
    }
}
