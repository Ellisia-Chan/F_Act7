using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    public static InventoryManager Instance { get; private set; }

    public event Action<InventoryItem> OnItemAdded;

    public List<InventoryItem> inventory = new List<InventoryItem>();

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.LogWarning("InventoryManager: Instance already exists!");
            Destroy(gameObject);
        }
    }

    public void AddItem(string itemName) {
        InventoryItem item = inventory.Find(i => i.itemName == itemName);

        if (item != null) {
            item.itemCount++;
            OnItemAdded?.Invoke(item);
        } else {
            Debug.Log("Added " + itemName + " to inventory");
            InventoryItem newItem = new InventoryItem(itemName, 1);
            inventory.Add(newItem);
            OnItemAdded?.Invoke(newItem);
        }

    }

    public int GetCount(string itemName) {
        InventoryItem item = inventory.Find(i => i.itemName == itemName);
        return item != null ? item.itemCount : 0;
    }

    private void OnDestroy() {
        if (Instance == this) {
            Instance = null;
        }
    }
}
