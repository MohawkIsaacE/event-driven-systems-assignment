using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A2_ColouredDoor : MonoBehaviour
{
    public Colour doorColour;
    private BoxCollider collider;
    private MeshRenderer doorMaterial;

    public Character player;

    private float opaqueAlpha = 1f;
    private float transparentAlpha = 0.5f;

    private void Awake()
    {
        //currentAlpha = opaqueAlpha;
        collider = GetComponent<BoxCollider>();
        doorMaterial = GetComponent<MeshRenderer>();
    }
    public void ChangeTransparency()
    {
        // Toggle the transparency of the door colour and toggle collision
        if (doorColour == player.PlayerColour) // When player is same colour as door
        {
            collider.enabled = false;

            Color color = doorMaterial.material.color;
            color.a = transparentAlpha;
            doorMaterial.material.color = color;
        }
        else if (doorColour != player.PlayerColour) // When player is NOT same colour as door
        {
            collider.enabled = true;

            Color color = doorMaterial.material.color;
            color.a = opaqueAlpha;
            doorMaterial.material.color = color;
        }
        else
        {
            Debug.Log("Error (A2_ColouredDoor): Player colour not found");
        }
    }
}
