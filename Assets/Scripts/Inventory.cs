using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour, IHittable
{
    [HideInInspector]
    public UnityEvent<InventoryItem> OnItemCollected;

    public InventoryItem item;

    public void Awake()
    {
        if (OnItemCollected == null) OnItemCollected = new UnityEvent<InventoryItem>();
    }

    public void Hit(GameObject otherGameObject)
    {
        // Problem with inventory limits
        Destroy(gameObject);

        OnItemCollected.Invoke(item);
    }
}
