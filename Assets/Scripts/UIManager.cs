using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public TextMeshProUGUI pumpkinsText;
    public TextMeshProUGUI coffinsText;
    public TextMeshProUGUI lanternsText;

    public void UpdateInventoryUI()
    {
        //UpdatePumpkinsUI();
        // Get inventory quantity directly from the inventory manager
        int pumpkinsAmount = inventoryManager.inventory[InventoryItem.Pumpkin];
        pumpkinsText.text = $"Pumpkins: {pumpkinsAmount}";

        int coffinsAmount = inventoryManager.inventory[InventoryItem.Coffin];
        coffinsText.text = $"Coffins: {coffinsAmount}";

        int lanternsAmount = inventoryManager.inventory[InventoryItem.Lantern];
        lanternsText.text = $"Lanterns: {lanternsAmount}";
    }

    public void UpdatePumpkinsUI()
    {

    }
}
