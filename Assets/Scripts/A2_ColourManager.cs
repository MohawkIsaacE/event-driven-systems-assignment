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
        player.PlayerColour = newColour;
        OnColourChanged.Invoke();
    }
}
