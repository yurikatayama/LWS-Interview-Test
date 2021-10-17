using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Item List", menuName = "Inventory/Item List", order = 0)]
public class ItemList : ScriptableObject {
    public List<Item> items;
}