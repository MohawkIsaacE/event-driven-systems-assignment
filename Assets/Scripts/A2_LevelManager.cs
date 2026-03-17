using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A2_LevelManager : MonoBehaviour
{
    // The level manager is responsible for connecting other game systems
    // A2 Additions/Changes
    public A2_UIManager uiManager;
    public A2_ColourManager colourManager;

    public GameObject ColourChangers;
    public GameObject ColouredDoors;

    // the level manager is responsible for connecting the core game system events
    // notice that these events have arguments - it's not possible to pass arguments to
    // events in Unity when using the Editor (what we did in Module 1)
    // arguments make the events more flexible

    private void Start()
    {
        // A2 Additions/Changes
        colourManager.OnColourChanged.AddListener(uiManager.UpdateColourUI);

        foreach (Transform changer in ColourChangers.transform)
        {
            A2_ColourChanger colourChanger = changer.GetComponent<A2_ColourChanger>();
            colourChanger.OnColourChangerHit.AddListener(colourManager.ColourChanged);
        }

        foreach (Transform door in ColouredDoors.transform)
        {
            A2_ColouredDoor colouredDoor = door.GetComponent<A2_ColouredDoor>();

        }
    }
}
