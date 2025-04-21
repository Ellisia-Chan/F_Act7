using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private Transform itemSlotParent;

    private Dictionary<string, GameObject> itemSlots = new Dictionary<string, GameObject>();

    private void OnEnable() {
        if (InventoryManager.Instance != null) {
            InventoryManager.Instance.OnItemAdded += UpdateUI; 
        }
    }
    private void OnDisable() {
        if (InventoryManager.Instance == null) return;
        InventoryManager.Instance.OnItemAdded -= UpdateUI;
    }

    private void Start() {
        if (InventoryManager.Instance != null) {
            InventoryManager.Instance.OnItemAdded += UpdateUI;
        }
    }

    private void UpdateUI(InventoryItem item) {
        if (item == null) return;

        if (itemSlots.ContainsKey(item.itemName)) {
            UpdateItemSlot(item);
        } else {
            CreateItemSlot(item);
        }
    }

    private void CreateItemSlot(InventoryItem item) {
        GameObject slot = Instantiate(itemSlotPrefab, itemSlotParent);
        Image icon = slot.transform.Find("Icon").GetComponent<Image>();
        TextMeshProUGUI countText = slot.transform.Find("CountTxt").GetComponent<TextMeshProUGUI>();

        icon.sprite = item.itemImage;
        countText.text = item.itemCount.ToString();
        itemSlots[item.itemName] = slot;
    }

    private void UpdateItemSlot(InventoryItem item) {
        GameObject slot = itemSlots[item.itemName];
        TextMeshProUGUI countText = slot.transform.Find("CountTxt").GetComponent<TextMeshProUGUI>();

        countText.text = item.itemCount.ToString();
    }
}
