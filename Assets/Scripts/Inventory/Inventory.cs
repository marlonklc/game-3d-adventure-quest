using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour {

    public GameObject inventoryCanvas;
    public GameObject slotsContainer;
    
    public static Inventory Instance;
    
    private List<InventorySlot> slots;

    public AudioClip openInventorySfx;
    public AudioClip closeInventorySfx;

    private void Awake() {
        Instance = this;
        
        slots = new List<InventorySlot>(slotsContainer.GetComponentsInChildren<InventorySlot>(true));
    }

    private void Update() {
        
        if (Keyboard.current.escapeKey.wasPressedThisFrame) {
            inventoryCanvas.SetActive(false);
            AudioManager.Instance.PlaySFX(closeInventorySfx);
            //Player.Instance.isPaused = false;
        }
    }

    public void AddItem(ItemData itemData) {
        InventorySlot firstSlotEmpty = slots.FirstOrDefault(slot => slot.itemData == null);

        if (firstSlotEmpty != null) {
            firstSlotEmpty.itemData = itemData;
        }
    }

    public void ShowInventory() {
       // Player.Instance.isPaused = true;
        AudioManager.Instance.PlaySFX(openInventorySfx);
        inventoryCanvas.SetActive(true);
    }
}
