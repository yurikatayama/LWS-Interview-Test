using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    Hat,
    Shirt
}

[System.Serializable]
public struct Item {
    public RuntimeAnimatorController animator;
    public ItemType type;
    public Sprite icon;
    public int price;
    public string ID;
    public string name;
    [TextArea (5, 20)] public string description;
}

[System.Serializable]
public struct InventoryItem {
    public Sprite icon;
    public string ID;
    public string name;
}