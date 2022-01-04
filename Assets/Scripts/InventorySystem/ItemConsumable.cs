using System;
using UnityEngine;

[Serializable]
public class ItemConsumable : Item
{
    public enum ConsumableType
    {
        Carrot,
        Potato,
        Potion
    }

    [SerializeField] private ConsumableType type;
    public ConsumableType Type => type;
}
