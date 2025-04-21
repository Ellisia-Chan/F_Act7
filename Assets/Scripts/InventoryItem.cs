using System;
using UnityEngine;

[Serializable]
public class InventoryItem {
    public string itemName;
    public int itemCount;
    public Sprite itemImage;

    public InventoryItem(string itemName, int itemCount) {
        this.itemName = itemName;
        this.itemCount = itemCount;
        itemImage = Resources.Load<Sprite>($"Icons/{itemName}");
    }
}
