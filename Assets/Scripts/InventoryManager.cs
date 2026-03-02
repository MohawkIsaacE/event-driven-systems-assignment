using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnInventoryChanged;

    public Dictionary<InventoryItem, int> inventory = new Dictionary<InventoryItem, int>();

    public void Awake()
    {
        if (OnInventoryChanged == null) OnInventoryChanged = new UnityEvent();

        // Initialize all inventory item keys
        inventory[InventoryItem.Pumpkin] = 0;
        inventory[InventoryItem.Lantern] = 0;
        inventory[InventoryItem.Coffin] = 0;
    }

    public void PickUpInventory(InventoryItem item)
    {
        // Key is guaranteed to exist
        inventory[item] += 1;
        OnInventoryChanged.Invoke();
    }

    public void DropInventory(InventoryItem item)
    {
        if (inventory[item] > 0)
        {
            inventory[item] -= 1;
            OnInventoryChanged.Invoke();
        }
    }
}
