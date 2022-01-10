// using System;
// using UnityEngine;
//
// /// <summary>
// /// The struct is used to store dynamic data on individual InventoryItem instance
// /// </summary>
// [Serializable]
// public struct ItemDataHolder
// {
//     private int width;
//     private int height;
//     private Sprite itemIcon;
//     private ItemType type;
//     private int? subType;
//
//     public int Width => width;
//     public int Height => height;
//     public Sprite ItemIcon => itemIcon;
//     public ItemType Type => type;
//     public int? SubType => subType;
//
//     public ItemDataHolder(BaseItem data)
//     {
//         width = data.InventoryItemWidth;
//         height = data.InventoryItemHeight;
//         itemIcon = data.InventoryItemIcon;
//         
//         if (data is ConsumableItem c && c)
//         {
//             type = c.Type;
//             subType = (int) c.SubType;
//         }
//         else if (data is WeaponItem w && w)
//         {
//             type = w.Type;
//             subType = (int) w.SubType;
//         }
//         else
//         {
//             type = ItemType.None;
//             subType = null;
//         }
//     }
// }
