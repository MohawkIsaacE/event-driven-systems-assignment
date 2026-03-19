using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class A2_ColourManager : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnColourChanged;

    public Character player;

    void Awake()
    {
        if (OnColourChanged == null) OnColourChanged = new UnityEvent();
    }

    public void ColourChanged(Colour newColour)
    {
        // Player colour changing logic
        // Only check which colour combination if the new colour is different than the player's current colour,
        // and if the player or the new colour are not the default colourless
        if (player.PlayerColour != Colour.None && newColour != Colour.None && player.PlayerColour != newColour )
        {
            // Brown colour change
            if (player.PlayerColour == Colour.Green  ||
                player.PlayerColour == Colour.Orange ||
                player.PlayerColour == Colour.Purple ||
                player.PlayerColour == Colour.Brown)
            {
                player.PlayerColour = Colour.Brown;
            }
            // Combining other colours
            // R + Y = O
            // R + B = P
            // B + Y = G
            // Double calculations for if colours are reversed
            else if (player.PlayerColour == Colour.Red && newColour == Colour.Yellow ||
                     player.PlayerColour == Colour.Yellow && newColour == Colour.Red)
            {
                player.PlayerColour = Colour.Orange;
            }
            else if (player.PlayerColour == Colour.Red && newColour == Colour.Blue ||
                     player.PlayerColour == Colour.Blue && newColour == Colour.Red)
            {
                player.PlayerColour = Colour.Purple;
            }
            else if (player.PlayerColour == Colour.Blue && newColour == Colour.Yellow ||
                     player.PlayerColour == Colour.Yellow && newColour == Colour.Blue)
            {
                player.PlayerColour = Colour.Green;
            }
        }
        else
        {
            player.PlayerColour = newColour;
        }

        OnColourChanged.Invoke();
    }
}
