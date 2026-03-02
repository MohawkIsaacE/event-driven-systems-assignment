using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IHittable
{
    public void Hit(GameObject otherGameObject)
    {
        Debug.Log("Inventory item hit");
    }
}
