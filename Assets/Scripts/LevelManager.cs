using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // The level manager is responsible for connecting other game systems
    public UIManager uiManager;
    public InventoryManager inventoryManager;

    // Gameplay objects
    public GameObject barriers1;
    public Toggle toggle1;
    public WallEye wallEye;
    public Door door;
    public GameObject inventoryItems;

    // the level manager is responsible for connecting the core game system events
    // notice that these events have arguments - it's not possible to pass arguments to
    // events in Unity when using the Editor (what we did in Module 1)
    // arguments make the events more flexible

    private void Start()
    {
        // Connect inventory and ui events
        inventoryManager.OnInventoryChanged.AddListener(uiManager.UpdateInventoryUI);
        //inventoryManager.OnInventoryChanged.AddListener();

        foreach(Transform child in inventoryItems.transform)
        {
            Inventory inventory = child.GetComponent<Inventory>();
            inventory.OnItemCollected.AddListener(inventoryManager.PickUpInventory);
        }

        // Connect gameplay system events
        foreach (Transform child in barriers1.transform)
        {
            Barrier barrier = child.GetComponent<Barrier>();
            toggle1.OnToggle.AddListener(barrier.Move);
        }

        toggle1.OnToggle.AddListener(wallEye.OpenClose);

        wallEye.OnEyeStateChanged.AddListener(LockDoorWallEye);
    }

    // "Buffer" the event with a function that has the correct arguments
    void LockDoorWallEye(WallEyeState eyeState)
    {
        LockDoor(eyeState, false);
    }
    void LockDoorInventory(WallEyeState eyeState)
    {
        if (inventoryManager.inventory[InventoryItem.Lantern] > 0)
        {
            LockDoor(WallEyeState.Closed, true);
        }
    }

    void LockDoor(WallEyeState eyeState, bool inventoryPickedUp)
    {
        if (eyeState == WallEyeState.Defeated)
        {
            door.SetLock(false);
        }
        else
        {
            door.SetLock(true);
        }
    }
}
